# .net-core-pattern-repository
Ejemplo de un crud con.net core y patron de diseño repository
organizado en 5 capas de la siguiente forma
	Respository: contiene la logica para manejar el modelo de base de datos
	Services: es la capa que representa los metodos mediante interfaz
	Tests: contiene pruenas unitarias de los servicios de webapi
	Web: es la capa de presentacion 
	ApiWeb: publica los metodos mediante servicios rest
