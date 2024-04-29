# [Лабораторна робота №3](https://learn.ztu.edu.ua/mod/assign/view.php?id=201666)

## Структурні шаблони.

**Мета:** навчитися реалізовувати структурні шаблони проєктування Адаптер, Декоратор, Міст, Компонувальник,
Проксі, Легковаговик.

TODO:
- [x] [Завдання 0](#user-content-завдання-0)
- [x] [Завдання 1](#user-content-завдання-1)
- [x] [Завдання 2](#user-content-завдання-2)
- [x] [Завдання 3](#user-content-завдання-3)
- [x] [Завдання 4](#user-content-завдання-4)
- [x] [Завдання 5](#user-content-завдання-5)
- [x] [Завдання 6](#user-content-завдання-6)

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
   [головному методі програми](ConsoleApp/Program.cs#L39).

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
   [головному методі програми](ConsoleApp/Program.cs#L51).

## [Завдання 3](BridgeLibrary)

Міст.

1. Ви працюєте над графічним редактором. Створіть базовий
   клас [`Shape`](BridgeLibrary/Shape.cs).
2. Створіть дочірні до `Shape` класи, [`Circle`](BridgeLibrary/Circle.cs), [`Square`](BridgeLibrary/Square.cs), 
   [`Triangle`](BridgeLibrary/Triangle.cs).
3. За допомогою шаблону [Міст](BridgeLibrary/IRender.cs) додайте можливість рендерингу
   кожної з фігур як векторної або растрової графіки (вивівши
   відповідне повідомлення у консоль, наприклад "Drawing Triangle
   as pixels").
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L71).

## [Завдання 4](ProxyLibrary)

Проксі.

1. Створіть клас [`SmartTextReader`](ProxyLibrary/SmartTextReader.cs), який вміє читати вміст
   текстового файлу і перетворювати його на двомірний масив якому
   зовнішній масив відповідає рядкам тексту, а вкладені масиви
   відповідають символам у відповідному рядку.
2. Створіть проксі для `SmartTextReader` з логуванням
   [`SmartTextChecker`](ProxyLibrary/SmartTextChecker.cs), який буде виводити інформацію про успішне
   відкриття, прочитання і закриття файлу, а також буде виводити
   загальну кількість рядків і символів у прочитаному тексті.
3. Створіть проксі для `SmartTextReader` з обмеженням доступу
   до певних файлів [`SmartTextReaderLocker`](ProxyLibrary/SmartTextReaderLocker.cs). Цей клас в конструкторі
   приймає регулярний вираз, по якому лімітується доступ до певної
   групи файлів. Якщо клієнт викликатиме метод для прочитання
   такого лімітованого файлу, замість прочитання файлу в консоль
   має виводитися повідомлення “Access denied!”.
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L87).

## [Завдання 5](CompositeLibrary)

Компонувальник.
 
1. Вам потрібно створити власну мову розмітки `LightHTML`.
2. Кожен елемент розмітки має наслідувати клас [`LightNode`](CompositeLibrary/ILightNode.cs).
3. Створіть два дочірніх класи від LightNode: [`LightElementNode`](CompositeLibrary/LightElementNode.cs),
   [`LightTextNode`](CompositeLibrary/LightTextNode.cs).
4. `LightTextNode` може містити лише текст.
5. `LightElementNode` може містити [будь-які LightNode](CompositeLibrary/LightElementNode.cs#L8).
   `LightElementNode` повинен мати інформацію про [назву тега](CompositeLibrary/LightElementNode.cs#L9), його
   [тип відображення](CompositeLibrary/LightElementNode.cs#L11) (блочний чи рядковий), 
   [тип закриття](CompositeLibrary/LightElementNode.cs#L10) (одиничний тег, як `<img/>` чи з закриваючим тегом)
   [список CSS класів](CompositeLibrary/LightElementNode.cs#L7),
   [кількість дочірніх елементів](CompositeLibrary/LightElementNode.cs#L14), а також має бути можливість виводити
   на екран його [outerHTML](CompositeLibrary/LightElementNode.cs#L43)
   і [innerHTML](CompositeLibrary/LightElementNode.cs#L35).
6. За допомогою своєї мови розмітки виведіть в консоль
   елемент сторінки на Ваш вибір (наприклад якусь таблицю, список
   тощо).
7. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/Program.cs#L109).

## [Завдання 6](FlyweightLibrary)

Легковаговик.

1. За допомогою свого `LightHTML` з завдання 5 перетворіть
   текст книги в HTML верстку за такими правилами:
   1. Перший рядок має бути елементом `<h1>`
   2. Якщо в рядку менше 20 символів - це має бути елемент
      `<h2>`
   3. Якщо рядок починається з пробільного символу - це має
      бути `<blockquote>`.
   4. В будь-якому іншому випадку - елемент `<p>`
2. [Покажіть скільки](ConsoleApp/Program.cs#L168) займає все дерево Вашої верстки, коли воно
   повністю утримується в памʼяті процесу.
3. Використайте [Легковаговик](FlyweightLibrary/NodesFlyweightFactory.cs) на Ваших класах 
   [HTML елементів](FlyweightLibrary/FlyweightNode.cs), щоб зменшити споживання памʼяті.
4. Покажіть правильність роботи свого коду запустивши його в
   [головному методі програми](ConsoleApp/SizeCalculator/FlyweightProvider.cs#L7).

Результат Завдання 5: 3336584 bytes ~ 3,336584 Mb

Результат Завдання 6: 3250040 bytes ~ 3,25004 Mb
