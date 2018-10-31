Proyect MVC ASP.NET Core 2.0 for data base MySql, MariaDB with individual identification of asp.net

El presente sistema de login, fue realizado pensando en la gestion de ventas, por lo cual se hace énfasis en la distribucion de cuentas por roles y bases de datos separadas
una para cuentas de usuarios del sistema y otra para productos, logica del negocio.

-- Tareas Realizadas -- 

NOTA: True o False hace referencia a si se concidera la tarea fianlizada.

Registro de usuarios = True

Autorizacion por Role = True

Servidor SMTP para Confirmacion de Email = True

Confirmacion de Email = True

Sistema de envio de correo electronico = True

Registro de usuarios con activacion por correo electronico = True. 

Reseteo de password = True

Configuracion de servidor smtp desde appsetting.json = true

Sistemas para gestion de cuentas, se toman las configuraciones desde appsetting. = true

Todas las cuentas que se cargan despues de admin y employee son por defecto Client.

Se permite establecer los roles para las cuentas y las cantidades de cuentas, que podran ser creadas para dichos roles desde appsetting. = true

Si no se desea establecer limite a la cantidad de cuentas para el role Client, el valor de Client tiene que establecerse en 0;

	  "UserRoles": {
		"Roles": "Admin=1;Employee=1;Client=0;"  <- Client=Cantidad Siempre al final.
	  },

Nota: El algoritmo de registro calcula la cantida de cuentas registradas para los roles al inicio del algoritmo.

Autenticación en dos pasos mediante aplicaciones:
	Microsoft Authenticator = No probado, no se muetra esta alternativa en la vista;
	Google Authenticator = true; Probada y funcionando;

-- Logins mediante servidores externos --

Login con Google = True

Login con Microsoft = True

Login con Facebook = True

Login con LinkedIn = True

Login con Twitch = True