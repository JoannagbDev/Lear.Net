# Introducción

En este módulo, se explica cómo crear un servicio RESTful multiplataforma mediante controladores de la API web de ASP.NET Core con .NET y C#.

Para el desarrollo local, usamos la CLI (interfaz de la línea de comandos) de .NET y Visual Studio Code. Cuando complete este módulo, podrá aplicar sus conceptos mediante un entorno de desarrollo como Visual Studio (Windows). También puede aplicar los conceptos al desarrollo continuo mediante Visual Studio Code (Windows, Linux y macOS).

## Escenario de ejemplo

Imagine que es empleado de una empresa de pizzas llamada SuNombrePizza. El administrador le pide que desarrolle un servicio RESTful de administración del inventario de pizzas como requisito previo para el escaparate web y la aplicación móvil de la empresa. El servicio debe permitir la adición, visualización, modificación y eliminación de tipos de pizzas; un uso estandarizado de los verbos de acción HTTP más conocidos como crear, leer, actualizar y eliminar (CRUD).

## ¿Qué vamos a hacer?

En este módulo, se crea una nueva aplicación de API web con ASP.NET Core y se aprende a ejecutarla y probarla desde la línea de comandos. Luego se agrega un almacén de datos y un nuevo controlador de API. Por último, se implementan y se prueban los métodos de la API para crear, leer, actualizar y eliminar pizzas del almacén de datos.

## ¿Cuál es el objetivo principal?

Al final de esta sesión será capaz de crear nuevas aplicaciones de API web usando ASP.NET Core, y habrá aprendido cómo crear controladores de API que implementen una lógica CRUD básica.

# REST de ASP.NET Core

Al ir a una página web, el servidor web se comunica con el explorador mediante HTML, CSS y JavaScript. Por ejemplo, si interactúa con la página enviando un formulario de registro o seleccionando un botón de compra, el navegador envía la información al servidor web.

De forma parecida, los servidores web pueden comunicarse mediante servicios web con una amplia gama de clientes, como exploradores, dispositivos móviles y otros servidores web. Los clientes de API se comunican con el servidor a través de HTTP, y los dos intercambian información mediante un formato de datos como JSON o XML. Las API se suelen usar en aplicaciones de página única (SPA) que realizan la mayor parte de la lógica de interfaz de usuario en un explorador web. La comunicación con el servidor web se produce principalmente a través de las API web.

## REST: un patrón común para compilar API con HTTP

Transferencia de estado representacional (REST) es un estilo arquitectónico para compilar servicios web. Las solicitudes REST se realizan a través de HTTP. Usan los mismos verbos HTTP que usan los exploradores web para recuperar páginas web y enviar datos a los servidores. Los verbos son:

- **GET**: Recuperar datos del servicio web.
- **POST**: Crear un nuevo elemento de datos en el servicio web.
- **PUT**: Actualizar un elemento de datos en el servicio web.
- **PATCH**: Actualizar un elemento de datos en el servicio web describiendo un conjunto de instrucciones sobre cómo se debe modificar el elemento. La aplicación de ejemplo de este módulo no usa este verbo.
- **DELETE**: Eliminar un elemento de datos en el servicio web.

Las API de servicio web que se adhieren a REST se denominan API de RESTful. Se definen a través de:

- Identificador URI base.
- Métodos HTTP, como GET, POST, PUT, PATCH o DELETE.
- Un tipo de medio para los datos, como notación de objetos JavaScript (JSON) o XML.

Una API a menudo tiene que proporcionar servicios para unas cuantas cosas diferentes, aunque relacionadas. Por ejemplo, la API de pizzas puede administrar pizzas, clientes y pedidos. Usamos enrutar para asignar URI (identificador de recurso uniforme) a divisiones lógicas del código, de modo que las solicitudes a `https://localhost:5000/pizza` se enruten a `PizzaController` y las solicitudes a `https://localhost:5000/order` lo hagan a `OrderController`.

## Ventajas de crear API en ASP.NET Core

Con ASP.NET se pueden usar el mismo marco y los mismos patrones para compilar páginas web y servicios. Puede reutilizar clases de modelos y lógica de validación, e incluso servir a páginas web y servicios en paralelo en el mismo proyecto. Este enfoque tiene ventajas:

- **Serialización simple**: ASP.NET diseñado para experiencias web modernas. Los puntos de conexión serializan automáticamente las clases en JSON con el formato correcto de serie. No se necesita ninguna configuración especial. Puede personalizar la serialización para los puntos de conexión con requisitos únicos.
- **Autenticación y autorización**: por motivos de seguridad, los puntos de conexión de API tienen compatibilidad integrada con JSON Web Token (JWT) estándares del sector. La autorización basada en directivas ofrece la flexibilidad necesaria para definir reglas de control de acceso eficaces en el código.
- **Enrutamiento junto con el código**: ASP.NET permite definir rutas y verbos en línea con el código, mediante atributos. Los datos de la ruta de acceso de la solicitud, la cadena de consulta y el cuerpo de la solicitud se enlazan automáticamente a parámetros de método.
- **HTTPS predeterminado**: HTTP es una parte importante de las API web modernas y profesionales. Se basa en el cifrado de un extremo a otro para proporcionar privacidad y ayudar a garantizar que las llamadas API no se intercepten ni se modifiquen entre el cliente y el servidor.

ASP.NET proporciona compatibilidad con HTTPS de serie. Genera automáticamente un certificado de prueba y lo importa fácilmente para habilitar HTTPS local de modo que puede ejecutar y depurar las aplicaciones de forma segura antes de publicarlas.

## Uso compartido de código y conocimientos con aplicaciones .NET

Puede usar sus aptitudes y el ecosistema de .NET para compartir la lógica de la API web con otras aplicaciones compiladas con .NET, como móviles, web, escritorio y servicios.

## Prueba de API web mediante .NET HTTP REPL

Al desarrollar un sitio web tradicional, normalmente el trabajo se ve y se prueba en un explorador web. Las API web aceptan y devuelven datos en lugar de HTML, por lo que un explorador web no es la mejor herramienta de pruebas de API web.

Una de las opciones más fáciles para explorar API web e interactuar con ellas es .NET HTTP REPL (read-evaluate-print loop). Es una manera sencilla y popular de compilar entornos de línea de comandos interactivos. En la unidad siguiente va a crear una API web simple y a interactuar con ella mediante .NET HTTP REPL.

## Fuente

Este ejercicio y la información proporcionada son parte de Microsoft Learn, una plataforma de aprendizaje interactivo que ofrece recursos y módulos para desarrollar habilidades técnicas.