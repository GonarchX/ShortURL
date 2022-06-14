##
Задание.

**Создать сайт с функцией сокращения ссылок URL.**

1. В качестве платформы нужно использовать ASP.NET Core. 
2. Разработать на языке C# функциональность для сокращения ссылок; 
3. Организовать переход по короткому URL с подсчетом переходов; 
4. На главной странице должен быть размещена таблица со следующими столбцами:

- Длинный URL; 

- Сокращенный URL; 

- Дата создания; 

- Количество переходов.

(Ниже не реализовал, т.к. не верстка отдельных страниц с Razor Pages - боль + проект больше нацелен на ознакомление с функционалом бэкенда)

5. Реализовать возможность удаления элемента из списка; 
6. Создать страницу создания/редактирования элемента на которой будет использоваться функциональность для сокращения ссылок;
7. Хранение данных таблицы реализовать в базе данных MySQL. Сокращенные ссылки URL должны создаваться так, чтобы их нельзя было предугадать.Нельзя создавать ссылки по простому последовательному арифметическому порядку.

##

Основной целью создание приложения было знакомство с:

1. ASP.NET Core MVC Framework (v. 5)
2. EntityFramework (v. 5.0.1.3)
3. Создание HTML верстки (хотя бОльшое количество решений было взято из [документации для BootsTrap](https://getbootstrap.com/docs/4.0/getting-started/introduction/) )
4. Создание стилей для отдельных элементов на HTML странице с помощью CSS 
5. Использование JavaScript для копирования текста из input элемента в буфер обмена 
