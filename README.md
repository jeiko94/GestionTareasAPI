Iniciar Sesión para Obtener un Token JWT:

Abre Swagger UI (https://localhost:{puerto}/swagger).
Navega al endpoint POST: api/Auth/login.
Proporciona las credenciales válidas (user / password).
Recibe el token JWT.
Proteger Endpoints con el Token:

En Swagger, haz clic en el botón "Authorize".
Introduce el token recibido con el prefijo Bearer .
Ahora, podrás acceder a los endpoints protegidos y breve ya esta la cosa echa.
