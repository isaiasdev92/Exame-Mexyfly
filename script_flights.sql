CREATE DATABASE RESERVATION_V1;
USE RESERVATION_V1;

-- Tabla de usuarios
CREATE TABLE Tbl_User (
    UserId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para el usuario
    Username VARCHAR(50) UNIQUE NOT NULL, -- Nombre de usuario
    PasswordHash VARCHAR(255) NOT NULL, -- Contraseña en formato hash
    RoleUser ENUM('Admin', 'Client') NOT NULL, -- Rol del usuario: Admin o Client
    IsActive BOOLEAN DEFAULT TRUE, -- Indica si el usuario está activo
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del usuario
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del usuario
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT -- Usuario que actualizó este registro
);

-- Tabla de aeropuertos
CREATE TABLE Tbl_Airport (
    AirportId CHAR(3) PRIMARY KEY, -- Código único del aeropuerto: por ejemplo, SLW, JFK
    NameAirport VARCHAR(100) NOT NULL, -- Nombre oficial del aeropuerto
    City VARCHAR(100), -- Ciudad donde se encuentra el aeropuerto
    Country VARCHAR(100), -- País donde está ubicado el aeropuerto
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT -- Usuario que actualizó este registro
);

-- Tabla para información extendida de los usuarios, que administrarán la plataforma,.
CREATE TABLE Tbl_UserInfo (
    UserInfoId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para los datos adicionales
    UserId BIGINT NOT NULL, -- Referencia al usuario en Tbl_User
    FirstName VARCHAR(100) NOT NULL, -- Nombre del usuario
    LastNameP VARCHAR(100) NOT NULL, -- Apellido paterno del usuario
    LastNameM VARCHAR(100), -- Apellido materno del usuario
    Email VARCHAR(100) UNIQUE NOT NULL, -- Correo electrónico del usuario
    PhoneNumber VARCHAR(15), -- Número de teléfono del usuario
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (UserId) REFERENCES Tbl_User(UserId) -- Relación con la tabla de usuarios
);

-- Tabla de clientes
CREATE TABLE Tbl_Client (
    ClientId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para cada cliente
    UserId BIGINT, -- Referencia al usuario en Tbl_User
    FirstName VARCHAR(100) NOT NULL, -- Nombre del usuario
    LastNameP VARCHAR(100) NOT NULL, -- Apellido paterno del usuario
    LastNameM VARCHAR(100), -- Apellido materno del usuario
    Email VARCHAR(100) UNIQUE NOT NULL, -- Correo electrónico del usuario
    PhoneNumber VARCHAR(15), -- Número de teléfono del usuario
    RegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha en que el cliente se registró
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (UserId) REFERENCES Tbl_User(UserId) -- Relación con la tabla de usuarios
);

-- Tabla de categorías de boletos
CREATE TABLE Tbl_Category (
    CategoryId INT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para la categoría
    CategoryName VARCHAR(50) NOT NULL UNIQUE -- Nombre de la categoría de boleto: por ejemplo, Business, Economy
);

-- Tabla de vuelos
CREATE TABLE Tbl_Flight (
    FlightId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para el vuelo
    FlightCode VARCHAR(10) UNIQUE NOT NULL, -- Código del vuelo: por ejemplo, INT-365
    OriginAirportId CHAR(3) NOT NULL, -- Código del aeropuerto de origen
    DestinationAirportId CHAR(3) NOT NULL, -- Código del aeropuerto de destino
    DepartureDateTime DATETIME NOT NULL, -- Fecha y hora programada de salida
    TotalSeats INT NOT NULL, -- Número total de asientos disponibles en el vuelo
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (OriginAirportId) REFERENCES Tbl_Airport(AirportId), -- Relación con el aeropuerto de origen
    FOREIGN KEY (DestinationAirportId) REFERENCES Tbl_Airport(AirportId) -- Relación con el aeropuerto de destino
);

-- Tabla de tarifas de boletos
CREATE TABLE Tbl_Rate (
    RateId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para la tarifa
    FlightId BIGINT NOT NULL, -- ID del vuelo asociado a esta tarifa
    CategoryId INT NOT NULL, -- ID de la categoría de boleto asociada a esta tarifa
    Price DECIMAL(10, 2) NOT NULL, -- Precio del boleto para esta categoría y vuelo
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (FlightId) REFERENCES Tbl_Flight(FlightId), -- Relación con el vuelo
    FOREIGN KEY (CategoryId) REFERENCES Tbl_Category(CategoryId) -- Relación con la categoría
);

-- Tabla de boletos
CREATE TABLE Tbl_Ticket (
    TicketId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para el boleto
    ClientId BIGINT NOT NULL, -- ID del cliente asociado al boleto
    IssueDate DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha en que se emitió el boleto
    TotalPrice DECIMAL(10, 2) NOT NULL, -- Precio total del boleto
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (ClientId) REFERENCES Tbl_Client(ClientId) -- Relación con el cliente
);

-- Tabla de segmentos de boletos
CREATE TABLE Tbl_Segment (
    SegmentId BIGINT AUTO_INCREMENT PRIMARY KEY, -- Identificador único para el segmento
    TicketId BIGINT NOT NULL, -- ID del boleto asociado a este segmento
    FlightId BIGINT NOT NULL, -- ID del vuelo asociado a este segmento
    SeatNumber VARCHAR(5), -- Número de asiento asignado para este segmento
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP, -- Fecha de creación del registro
    UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP, -- Fecha de última actualización del registro
    CreatedBy BIGINT, -- Usuario que creó este registro
    UpdatedBy BIGINT, -- Usuario que actualizó este registro
    FOREIGN KEY (TicketId) REFERENCES Tbl_Ticket(TicketId), -- Relación con el boleto
    FOREIGN KEY (FlightId) REFERENCES Tbl_Flight(FlightId) -- Relación con el vuelo
);


INSERT INTO `RESERVATION_V1`.`Tbl_User`
( `Username`, `PasswordHash`, `RoleUser`, `IsActive`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`)
VALUES
('admin01', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Admin', '1', now(), now(), null, null);

SET @id = LAST_INSERT_ID();
INSERT INTO `RESERVATION_V1`.`Tbl_UserInfo`
( `UserId`, `FirstName`, `LastNameP`, `LastNameM`, `Email`, `PhoneNumber`, `CreatedAt`, `UpdatedAt`, `CreatedBy`, `UpdatedBy`)
VALUES
( @id, 'John', 'Smith', 'Gonzalez', 'john@mail.com', '1234567890', now(), now(), null, null);

INSERT INTO Tbl_User (UserId, Username, PasswordHash, RoleUser, IsActive, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES
(2, 'maria.lopez', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(3, 'carlos.ramirez', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(4, 'ana.gonzalez', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(5, 'luis.hernandez', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(6, 'sofia.torres', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(7, 'miguel.rojas', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(8, 'daniela.navarro', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(9, 'jorge.salas', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null),
(10, 'elena.mendoza', 'MawCs3W9JjKuBF4sQNLXE+nXxP0vJgt1sXaeL2/jX7c=', 'Client', TRUE, NOW(), NOW(), null, null);


INSERT INTO Tbl_Client (ClientId, UserId, FirstName, LastNameP, LastNameM, Email, PhoneNumber, RegistrationDate, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES
(101, 1, 'Juan', 'Pérez', 'García', 'juan.perez@email.com', '5512345678', NOW(), NOW(), NOW(), null, null),
(102, 2, 'María', 'López', 'Hernández', 'maria.lopez@email.com', '5523456789', NOW(), NOW(), NOW(), null, null),
(103, 3, 'Carlos', 'Ramírez', 'Flores', 'carlos.ramirez@email.com', '5534567890', NOW(), NOW(), NOW(), null, null),
(104, 4, 'Ana', 'González', 'Martínez', 'ana.gonzalez@email.com', '5545678901', NOW(), NOW(), NOW(), null, null),
(105, 5, 'Luis', 'Hernández', 'Sánchez', 'luis.hernandez@email.com', '5556789012', NOW(), NOW(), NOW(), null, null),
(106, 6, 'Sofía', 'Torres', 'Luna', 'sofia.torres@email.com', '5567890123', NOW(), NOW(), NOW(), null, null),
(107, 7, 'Miguel', 'Rojas', 'Vega', 'miguel.rojas@email.com', '5578901234', NOW(), NOW(), NOW(), null, null),
(108, 8, 'Daniela', 'Navarro', 'Castro', 'daniela.navarro@email.com', '5589012345', NOW(), NOW(), NOW(), null, null),
(109, 9, 'Jorge', 'Salas', 'Moreno', 'jorge.salas@email.com', '5590123456', NOW(), NOW(), NOW(), null, null),
(110, 10, 'Elena', 'Mendoza', 'Cruz', 'elena.mendoza@email.com', '5501234567', NOW(), NOW(), NOW(), null, null);




INSERT INTO Tbl_Airport (AirportId, NameAirport, City, Country, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES 
('MEX', 'Aeropuerto Internacional de México', 'Ciudad de México', 'México', NOW(), NOW(), null, null),
('LAX', 'Los Angeles International', 'Los Ángeles', 'Estados Unidos', NOW(), NOW(), null, null),
('JFK', 'John F. Kennedy International', 'Nueva York', 'Estados Unidos', NOW(), NOW(), null, null),
('NRT', 'Narita International', 'Narita', 'Japón', NOW(), NOW(), null, null),
('HND', 'Haneda International', 'Tokio', 'Japón', NOW(), NOW(), null, null),
('CDG', 'Charles de Gaulle', 'París', 'Francia', NOW(), NOW(), null, null),
('LHR', 'London Heathrow', 'Londres', 'Reino Unido', NOW(), NOW(), null, null),
('DXB', 'Dubai International', 'Dubái', 'Emiratos Árabes Unidos', NOW(), NOW(), null, null),
('SYD', 'Sydney Kingsford Smith', 'Sídney', 'Australia', NOW(), NOW(), null, null),
('GRU', 'São Paulo-Guarulhos', 'São Paulo', 'Brasil', NOW(), NOW(), null, null);


INSERT INTO Tbl_Category (CategoryId, CategoryName)
VALUES 
(1, 'Economy'),
(2, 'Business'),
(3, 'First Class'),
(4, 'Premium Economy'),
(5, 'Standard'),
(6, 'Flexible'),
(7, 'Saver'),
(8, 'Luxury'),
(9, 'Budget'),
(10, 'Corporate');


INSERT INTO Tbl_Flight (FlightId, FlightCode, OriginAirportId, DestinationAirportId, DepartureDateTime, TotalSeats, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES 
(1, 'MEX-LAX', 'MEX', 'LAX', '2024-12-04 08:00:00', 200, NOW(), NOW(), null, null),
(2, 'LAX-NRT', 'LAX', 'NRT', '2024-12-04 14:00:00', 250, NOW(), NOW(), null, null),
(3, 'NRT-HND', 'NRT', 'HND', '2024-12-05 18:00:00', 180, NOW(), NOW(), null, null),
(4, 'JFK-CDG', 'JFK', 'CDG', '2024-12-06 10:00:00', 300, NOW(), NOW(), null, null),
(5, 'CDG-LHR', 'CDG', 'LHR', '2024-12-06 14:00:00', 150, NOW(), NOW(), null, null),
(6, 'LHR-DXB', 'LHR', 'DXB', '2024-12-07 16:00:00', 220, NOW(), NOW(), null, null),
(7, 'DXB-SYD', 'DXB', 'SYD', '2024-12-08 22:00:00', 270, NOW(), NOW(), null, null),
(8, 'SYD-GRU', 'SYD', 'GRU', '2024-12-09 09:00:00', 190, NOW(), NOW(), null, null),
(9, 'GRU-MEX', 'GRU', 'MEX', '2024-12-10 15:00:00', 210, NOW(), NOW(), null, null),
(10, 'MEX-JFK', 'MEX', 'JFK', '2024-12-11 07:00:00', 240, NOW(), NOW(), null, null);


INSERT INTO Tbl_Rate (RateId, FlightId, CategoryId, Price, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES 
(1, 1, 1, 300.00, NOW(), NOW(), null, null),
(2, 1, 2, 600.00, NOW(), NOW(), null, null),
(3, 2, 1, 500.00, NOW(), NOW(), null, null),
(4, 2, 3, 900.00, NOW(), NOW(), null, null),
(5, 3, 1, 150.00, NOW(), NOW(), null, null),
(6, 3, 4, 300.00, NOW(), NOW(), null, null),
(7, 4, 1, 400.00, NOW(), NOW(), null, null),
(8, 4, 2, 800.00, NOW(), NOW(), null, null),
(9, 5, 1, 350.00, NOW(), NOW(), null, null),
(10, 5, 3, 700.00, NOW(), NOW(), null, null);

INSERT INTO Tbl_Ticket (TicketId, ClientId, IssueDate, TotalPrice, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES 
(1, 101, '2024-12-01 10:00:00', 600.00, NOW(), NOW(), null, null),
(2, 102, '2024-12-01 11:00:00', 950.00, NOW(), NOW(), null, null),
(3, 103, '2024-12-01 12:00:00', 700.00, NOW(), NOW(), null, null),
(4, 104, '2024-12-01 13:00:00', 800.00, NOW(), NOW(), null, null),
(5, 105, '2024-12-01 14:00:00', 650.00, NOW(), NOW(), null, null),
(6, 106, '2024-12-01 15:00:00', 400.00, NOW(), NOW(), null, null),
(7, 107, '2024-12-01 16:00:00', 550.00, NOW(), NOW(), null, null),
(8, 108, '2024-12-01 17:00:00', 750.00, NOW(), NOW(), null, null),
(9, 109, '2024-12-01 18:00:00', 500.00, NOW(), NOW(), null, null),
(10, 110, '2024-12-01 19:00:00', 850.00, NOW(), NOW(), null, null);


INSERT INTO Tbl_Segment (SegmentId, TicketId, FlightId, SeatNumber, CreatedAt, UpdatedAt, CreatedBy, UpdatedBy)
VALUES 
(1, 1, 1, '12A', NOW(), NOW(), null, null),
(2, 1, 2, '15B', NOW(), NOW(), null, null),
(3, 2, 3, '10C', NOW(), NOW(), null, null),
(4, 2, 4, '8A', NOW(), NOW(), null, null),
(5, 3, 5, '5B', NOW(), NOW(), null, null),
(6, 3, 6, '3C', NOW(), NOW(), null, null),
(7, 4, 7, '1A', NOW(), NOW(), null, null),
(8, 4, 8, '7D', NOW(), NOW(), null, null),
(9, 5, 9, '14C', NOW(), NOW(), null, null),
(10, 5, 10, '9B', NOW(), NOW(), null, null);

