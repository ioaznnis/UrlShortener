# UrlShortener
Сервис по сокращению URL

Требования, которым соответствует данный сервис:
1. Организация переход по короткому URL с подсчетом переходов;
1. Имеется страница (форма) создания/редактирования элемента, в которой будет использоваться функциональность для сокращения ссылок;
1. На главной странице (форме) размещен список в виде таблицы со следующими столбцами:
    1. Длинный URL;
    1. Сокращенный URL;
    1. Дата создания;
    1. Кол-во переходов.
1. Имеется возможность удаления элемента из списка;
1. Хранение данных организовано в базе данных MySQL;
1. Сокращенные URL не располагаются по порядку.

Осталось реализовать:
1. Подсчет переходов по ссылке
1. Возможность редактирования URL

Список того, что не реализовано (из того, что надо бы сделать, но в ТЗ не отражено) перенесен в todo list.

Подключение к БД:
Для подключения к БД необходимо в конфигурации указать параметры:
* "Database:UserID"
* "Database:Password"
https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.1&tabs=windows