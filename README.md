# Описание проекта  
Проект представляет собой консольное приложение, моделирующее бой между двумя воинами.  
В проекте используется **объектно-ориентированный подход** для реализации воинов и их сражения.

Классы и интерфейсы  
IWarrior - интерфейс, описывающий свойства и методы бойцов.  
Warrior - класс, реализующий интерфейс IWarrior, представляющий воина со свойствами "имя", "здоровье", "максимальная атака" и "максимальный блок".
Также содержит методы для генерации случайной атаки и блока.  
Battle - класс, содержащий методы для начала боя между двумя воинами и получения результата атаки.  
GameStartMessage - класс, отвечающий за вывод сообщения "START GAME".  
Запуск приложения  
При запуске приложения происходит вывод сообщения "START GAME", создание двух воинов (героя и монстра), инициирование боя между ними и вывод результатов сражения в консоль.  

Примечание  
Данный проект является примером применения объектно-ориентированного программирования (ООП) для моделирования сражения между двумя воинами в консольном приложении,  
демонстрируя использование интерфейсов, **классов, наследования и инкапсуляции**.
