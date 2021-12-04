# Xpymb.TestExercises.GameRepository

<h2>Описание</h2>
Реализация ASP.NET Core Web API сервиса для взаимодействия с базой данных, в которой хранятся данные о видеоиграх. 

Было реализовано:
- CRUD операции с базой данных на уровне API + API-метод для получения информации об играх определенного жанра
- 3 слоя абстракции (контроллер, сервис, база данных)

Использовано:
- .NET Core 3.1
- Entity Framework
- Swagger
- AutoMapper

<h2>Как запустить?</h2>

Для запуска проекта необходимы следующие модули:
- .NET Core 3.1 SDK (ссылка: https://dotnet.microsoft.com/download/dotnet/3.1)

<br>Чтобы запустить проект, выполните следующие действия:</br>


1) Клонировать репозиторий

- Через терминал:
<code>git clone https://github.com/Xpymb/Xpymb.TestExercises.GameRepository.git</code>

- Или при помощи GitHub Desktop. 
<br></br>

2) Перейти в клонированную папку

- Через терминал:
<code>cd Xpymb.TestExercises.GameRepository</code>
    
- Или при помощи проводника
<br></br>

3) Запустить проект скриптом

- Linux/MacOS: через терминал <code>./run.sh</code>
- Windows: через терминал <code>start run.bat</code> или запуском файла <code>run.bat</code> через проводник
<br></br>

Будет запущен веб-сервис на 5000(http) и 5001(https) портах

<h2>Описание API-методов</h2>

Для удобной навигации по REST-API методам был сконфигурирован Swagger, перейти к нему можно по адресу: 
- http://localhost:5000/swagger/index.html
- https://localhost:5001/swagger/index.html
<br></br>

1) <code>https://localhost:5001/api/GameInfo/get</code>

Тип метода: GET

Описание: позволяет получить информацию об игре по id игры в базе данных

<table>
    <tr>Параметры запроса:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
</table>

Пример запроса:

https://localhost:5001/api/GameInfo/get?id=d86226ac-9551-497b-b2f9-750651b15ab6

Пример ответа:

    {
      "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
      "name": "Battlefield 1",
      "gameStudio": "DICE",
      "gameTags": [
        0
      ]
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>
<br></br>

2) <code>https://localhost:5001/api/GameInfo/get-by-game-tag</code>

Тип метода: GET

Описание: позволяет получить информацию об играх по указанному жанру

<table>
    <tr>Параметры запроса:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>gameTag</td> <td>Жанр игры</td>
    </tr>
</table>

Пример запроса:

https://localhost:5001/api/GameInfo/get-by-game-tag?gameTag=1

Пример ответа:

    [
      {
        "id": "361612ef-b5b8-45d2-9db9-f854f167e2a3",
        "name": "ArcheAge",
        "gameStudio": "XL Games",
        "gameTags": [
          0,
          1
        ]
      },
      {
        "id": "aa67d796-9278-4a6e-b2b9-707c434ca2d9",
        "name": "Forza Horizon 5",
        "gameStudio": "Xbox Game Studios",
        "gameTags": [
          0,
          1,
          2
        ]
      }
    ]

<table>
    <tr>Параметры ответа: Массив элементов</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>
<br></br>

3) <code>https://localhost:5001/api/GameInfo/get-all</code>

Тип метода: GET

Описание: позволяет получить информацию всех играх в базе данных

Пример запроса:

https://localhost:5001/api/GameInfo/get-all

Пример ответа:

    [
      {
        "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
        "name": "Battlefield 1",
        "gameStudio": "DICE",
        "gameTags": [
          0
         ]
      },
      {
        "id": "361612ef-b5b8-45d2-9db9-f854f167e2a3",
        "name": "ArcheAge",
        "gameStudio": "XL Games",
        "gameTags": [
          0,
          1
        ]
      },
      {
        "id": "aa67d796-9278-4a6e-b2b9-707c434ca2d9",
        "name": "Forza Horizon 5",
        "gameStudio": "Xbox Game Studios",
        "gameTags": [
          0,
          1,
          2
        ]
      }
    ]

<table>
    <tr>Параметры ответа: Массив элементов</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>
<br></br>

4) <code>https://localhost:5001/api/GameInfo/create</code>

Тип метода: PUT

Описание: позволяет создать новую запись с информацией о игре в базе данных

<table>
    <tr>Тело запроса:</tr>
    <tr>
        <td>Поле</td> <td>Описание</td>
    </tr>
    <tr>
        <td>name (Обязательный)</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio (Обязательный)</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags (Обязательный)</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>

Пример запроса:

https://localhost:5001/api/GameInfo/create

Тело запроса:

    {
      "name": "New World",
      "gameStudio": "Amazon Game Studios",
      "gameTags": [
        0
      ]
    }

Пример ответа:

    {
      "id": "63a87236-dc81-478a-807c-33eb2c30dbcc",
      "name": "New World",
      "gameStudio": "Amazon Game Studios",
      "gameTags": [
        0
      ]
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>
<br></br>

5) <code>https://localhost:5001/api/GameInfo/update</code>

Тип метода: POST

Описание: позволяет изменить информацию о игре в базе данных

<table>
    <tr>Тело запроса:</tr>
    <tr>
        <td>Поле</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id (Обязательный)</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
    <tr>
        <td>isActive</td> <td>Включить/Выключить элемент</td>
    </tr>
</table>

Пример запроса:

https://localhost:5001/api/GameInfo/update

Тело запроса:

    {
      "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
      "name": "Hades",
      "gameStudio": "Supergiant Games",
      "gameTags": [
        0, 
        3,
        8
      ],
      "isActive": true
    }

Пример ответа:

    {
      "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
      "name": "Hades",
      "gameStudio": "Supergiant Games",
      "gameTags": [
        0,
        3,
        8
      ]
    }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>

Изменения в базе данных:

Было:

    {
      "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
      "name": "Battlefield 1",
      "gameStudio": "DICE",
      "gameTags": [
        0
      ]
    }

Стало:

    {
      "id": "d86226ac-9551-497b-b2f9-750651b15ab6",
      "name": "Hades",
      "gameStudio": "Supergiant Games",
      "gameTags": [
        0,
        3,
        8
      ]
    }

<br></br>

6) <code>https://localhost:5001/api/GameInfo/update</code>

Тип метода: DELETE

Описание: позволяет изменить информацию о игре в базе данных

<table>
    <tr>Параметры запроса:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
</table>

Пример запроса:

https://localhost:5001/api/GameInfo/delete?id=aa67d796-9278-4a6e-b2b9-707c434ca2d9

Пример ответа:

      {
        "id": "aa67d796-9278-4a6e-b2b9-707c434ca2d9",
        "name": "Forza Horizon 5",
        "gameStudio": "Xbox Game Studios",
        "gameTags": [
          0,
          1,
          2
        ]
      }

<table>
    <tr>Параметры ответа:</tr>
    <tr>
        <td>Параметр</td> <td>Описание</td>
    </tr>
    <tr>
        <td>id</td> <td>Id игры в базе данных</td>
    </tr>
    <tr>
        <td>name</td> <td>Название игры</td>
    </tr>
    <tr>
        <td>gameStudio</td> <td>Название студии разработчика</td>
    </tr>
    <tr>
        <td>gameTags</td> <td>Массив Enum жанров игры</td>
    </tr>
</table>

<h2>Schemas</h2>

1) GameTag (Enum)

<table>
    <tr>
        <td>Значение</td> <td>Название</td>
    </tr>
    <tr>
        <td>0</td> <td>Action</td>
    </tr>
    <tr>
        <td>1</td> <td>Arcade</td>
    </tr>
    <tr>
        <td>2</td> <td>Strategy</td>
    </tr>
    <tr>
        <td>3</td> <td>Adventure</td>
    </tr>
    <tr>
        <td>4</td> <td>Educational</td>
    </tr>
    <tr>
        <td>5</td> <td>Quest</td>
    </tr>
    <tr>
        <td>6</td> <td>InteractiveFiction</td>
    </tr>
    <tr>
        <td>7</td> <td>RPG</td>
    </tr>
    <tr>
        <td>8</td> <td>Fighting</td>
    </tr>
    <tr>
        <td>9</td> <td>Racing</td>
    </tr>
    <tr>
        <td>10</td> <td>Simulation</td>
    </tr>
    <tr>
        <td>11</td> <td>Sports</td>
    </tr>
    <tr>
        <td>12</td> <td>Puzzle</td>
    </tr>
    <tr>
        <td>13</td> <td>Tabletop</td>
    </tr>
    <tr>
        <td>14</td> <td>Other</td>
    </tr>
</table>
