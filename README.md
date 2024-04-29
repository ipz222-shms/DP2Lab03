# [Лабораторна робота №3](https://learn.ztu.edu.ua/mod/assign/view.php?id=201666)

## Структурні шаблони.

**Мета:** навчитися реалізовувати структурні шаблони проєктування Адаптер, Декоратор, Міст, Компонувальник,
Проксі, Легковаговик.

TODO:
- [x] [Завдання 0](#user-content-завдання-0)
- [x] [Завдання 1](#user-content-завдання-1)
- [x] [Завдання 2](#user-content-завдання-2)
- [ ] [Завдання 3](#user-content-завдання-3)
- [ ] [Завдання 4](#user-content-завдання-4)
- [ ] [Завдання 5](#user-content-завдання-5)
- [ ] [Завдання 6](#user-content-завдання-6)

---

## Завдання 0

Створення репозиторію.

## [Завдання 1](AdapterLibrary)

Адаптер.

1. Створіть клас [`Logger`](AdapterLibrary/Logger.cs), який буде мати методи `Log()`,
   `Error()`, `Warn()`, які виводять повідомлення в консоль різними
   кольорами (зеленим, червоним і оранжевим відповідно).
2. Створіть клас [`FileWriter`](AdapterLibrary/FileWriter.cs) з методами `Write()`, `WriteLine()`.
3. За допомогою шаблону Адаптер створіть [файловий логер](AdapterLibrary/LoggerFile.cs).
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L35).

## [Завдання 2](DecoratorLibrary)

Декоратор.

1. Ви розробляєте РПГ гру. Створіть класи героїв [`Warrior`](DecoratorLibrary/Warrior.cs), 
   [`Mage`](DecoratorLibrary/Mage.cs), [`Palladin`](DecoratorLibrary/Palladin.cs).
2. Для героїв створіть інвентар ([одяг](DecoratorLibrary/Armor.cs), [зброю](DecoratorLibrary/Weapon.cs), 
   [артефакти](DecoratorLibrary/Artifact.cs)), який може підходити будь-якому типу героїв, у вигляді
   [декораторів](DecoratorLibrary/BaseItem.cs).
3. Важливою вимогою є можливість використання декількох
   екземплярів інвентаря на герої одночасно.
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L47).

## [Завдання 3](BridgeLibrary)

Міст.

1. Ви працюєте над графічним редактором. Створіть базовий
   клас `Shape`.
2. Створіть дочірні до `Shape` класи, `Circle`, `Square`, `Triangle`.
3. За допомогою шаблону Міст додайте можливість рендерингу
   кожної з фігур як векторної або растрової графіки (вивівши
   відповідне повідомлення у консоль, наприклад "Drawing Triangle
   as pixels").
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L0).

## [Завдання 4](ProxyLibrary)

Проксі.

1. Створіть клас `SmartTextReader`, який вміє читати вміст
   текстового файлу і перетворювати його на двомірний масив якому
   зовнішній масив відповідає рядкам тексту, а вкладені масиви
   відповідають символам у відповідному рядку.
2. Створіть проксі для `SmartTextReader` з логуванням
   `SmartTextChecker`, який буде виводити інформацію про успішне
   відкриття, прочитання і закриття файлу, а також буде виводити
   загальну кількість рядків і символів у прочитаному тексті.
3. Створіть проксі для `SmartTextReader` з обмеженням доступу
   до певних файлів `SmartTextReaderLocker`. Цей клас в конструкторі
   приймає регулярний вираз, по якому лімітується доступ до певної
   групи файлів. Якщо клієнт викликатиме метод для прочитання
   такого лімітованого файлу, замість прочитання файлу в консоль
   має виводитися повідомлення “Access denied!”.
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L0).

## [Завдання 5](CompositeLibrary)

Компонувальник.

1. Вам потрібно створити власну мову розмітки `LightHTML`.
2. Кожен елемент розмітки має наслідувати клас `LightNode`.
3. Створіть два дочірніх класи від LightNode: `LightElementNode`, `LightTextNode`.
4. `LightTextNode` може містити лише текст.
5. `LightElementNode` може містити будь-які LightNode.
   `LightElementNode` повинен мати інформацію про назву тега, його
   тип відображення (блочний чи рядковий), тип закриття (одиничний
   тег, як `<img/>` чи з закриваючим тегом) список CSS класів,
   кількість дочірніх елементів, а також має бути можливість виводити
   на екран його outerHTML і innerHTML.
6. За допомогою своєї мови розмітки виведіть в консоль
   елемент сторінки на Ваш вибір (наприклад якусь таблицю, список
   тощо).
7. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L0).

## [Завдання 6](FlyweightLibrary)

Легковаговик.

1. За допомогою свого `LightHTML` з завдання 1 перетворіть
   текст книги в HTML верстку за такими правилами:
   1. Перший рядок має бути елементом `<h1>`
   2. Якщо в рядку менше 20 символів - це має бути елемент
      `<h2>`
   3. Якщо рядок починається з пробільного символу - це має
      бути `<blockquote>`.
   4. В будь-якому іншому випадку - елемент `<p>`
2. Покажіть скільки займає все дерево Вашої верстки, коли воно
   повністю утримується в памʼяті процесу.
3. Використайте Легковаговик на Ваших класах HTML
   елементів, щоб зменшити споживання памʼяті.
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L0).
