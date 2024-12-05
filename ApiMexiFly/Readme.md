
# **Backend - MexiFly**

Este proyecto es un backend para un sistema de reservaciones de boletos de avión para una agencia de viajes, denominado **MexiFly**. El backend permite a los administradores gestionar vuelos, aeropuertos, tarifas y usuarios, mientras que los clientes pueden buscar vuelos, reservar boletos y gestionar sus itinerarios.

El backend está desarrollado en **C#** y sigue principios de diseño limpio y escalable. Utiliza varias herramientas y librerías para mejorar la eficiencia, la validación de datos y la administración de la lógica de negocio.

---

### **Tecnologías Utilizadas:**

1. **C# .NET Core**  
   El backend está construido usando **.NET Core**, una plataforma de desarrollo moderna y eficiente que permite crear aplicaciones robustas y escalables.

2. **MediatR**  
   Se utiliza **MediatR** como patrón de diseño **Mediator**. Este patrón permite desacoplar las peticiones y respuestas entre componentes del sistema, facilitando la gestión de la lógica de negocio. MediatR gestiona las solicitudes, notificaciones y comandos de manera centralizada.  
   **Beneficio**: Promueve la separación de preocupaciones y hace el código más limpio y fácil de mantener.

3. **FluentValidation**  
   **FluentValidation** se utiliza para realizar validaciones complejas de los datos de entrada de manera fluida y legible.  
   **Beneficio**: Permite crear reglas de validación de manera declarativa y reutilizable, facilitando el mantenimiento y la evolución del sistema.

4. **AutoMapper**  
   **AutoMapper** se usa para mapear objetos de un tipo a otro de forma automática. Principalmente, se utiliza para convertir entidades de la base de datos a modelos de respuesta y viceversa.  
   **Beneficio**: Reduce el código repetitivo y facilita la conversión de datos entre diferentes capas de la aplicación.

5. **MySQL**  
   El sistema utiliza **MySQL** como sistema de gestión de bases de datos relacional para almacenar la información de vuelos, clientes, usuarios, tarifas y más.  
   **Script de base de datos**: `script_mexifly.sql` es el archivo SQL que contiene el esquema de las tablas necesarias para el sistema.

---

### **Pasos para Correr el Proyecto:**

1. **Instalar MySQL**  
   Asegúrate de tener **MySQL** instalado en tu máquina. Puedes descargarlo desde [aquí](https://dev.mysql.com/downloads/installer/).  
   Si ya tienes MySQL corriendo, asegúrate de tener las credenciales necesarias para acceder a la base de datos.

2. **Crear la Base de Datos**  
   Ejecuta el script `script_mexifly.sql` en tu servidor MySQL para crear las tablas necesarias para el sistema.  
   ```sql
   source script_mexifly.sql;

3. **Configurar la Conexión a la Base de Datos usando secretos de dotnet core**
En el archivo de configuración `appsettings.json`, configura la cadena de conexión para que apunte a tu base de datos MySQL:

   ```json
   "ConnectionStrings": {
   "DefaultConnection": "Server=localhost;Database=RESERVATION_V1;User=root;Password=pwd-3192;TreatTinyAsBoolean=true;SslMode=Required"
   }
   ```

Se usa secretos para establecer forma mas seguro la cadena de conexión.

Correr el comando  `dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost;Database=RESERVATION_V1;User=root;Password=pwd-3192;TreatTinyAsBoolean=true;SslMode=Required"` en caso de error, correr el comando `dotnet user-secrets init` y correr nuevamente el primer comando.


4. **Restaurar Paquetes NuGet**

Asegúrate de tener todos los paquetes necesarios instalados. Puedes hacerlo ejecutando el siguiente comando:

`dotnet restore` 

5. **Ejecutar el Proyecto**

Corre el proyecto con el siguiente comando:

`dotnet run` 

6. **Verificar el Funcionamiento**

El backend debería estar corriendo en el puerto configurado (por defecto, en `localhost:5000`). Puedes verificar las rutas de la API o usar una herramienta como **Postman** para interactuar con el sistema.


### **Flujo de Lógica de Negocio**

1.  **Autenticación y Roles**  
    Los usuarios pueden registrarse como administradores o clientes. Los administradores tienen control total sobre el sistema (gestión de vuelos, tarifas, aeropuertos), mientras que los clientes solo pueden realizar reservaciones de boletos.
    
2.  **Vuelos y Reservaciones**  
    Los clientes pueden buscar vuelos disponibles, seleccionar su vuelo y categoría (Business, Economy) y proceder a reservar boletos. La disponibilidad de asientos se actualiza en tiempo real.
    
3.  **Administración de Aeropuertos y Tarifas**  
    Los administradores gestionan aeropuertos, vuelos y tarifas. Cada vuelo tiene asociadas tarifas por categoría, que son modificables a través de la interfaz administrativa.



## Credenciales

Username: Isaias
password: 12345678