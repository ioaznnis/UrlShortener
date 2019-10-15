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

Осталось реализовать (в порядке приоритетности):
1. Подсчет переходов по ссылке
1. Хранение данных в БД MySQL
1. Возможность редактирования URL

Не реализовано (из того, что надо бы сделать, но в ТЗ не отражено):
1. Валидация корректности сокращаемого URL
1. Обработка отсутствия короткого URL в БД
