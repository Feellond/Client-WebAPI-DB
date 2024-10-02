# Client-WebAPI-DB
Взаимодействие клиента на WPF (на базе архитектуры MVVM) через httpClient к WebAPI (.NET Core) с БД на SQLite. Версия .Net 8.0
Клиент и WebAPI - два отдельных приложения. 
### Для работы необходимо через проект сначала запустить WebAPI, затем взаимодействовать с ним через клиентское приложение. Основная задача была в взаимодействии, WebAPI не было нужды настраивать:
<p align="center">
  <img src="https://github.com/user-attachments/assets/e5d1d648-6aab-4be6-a793-6237fe42a0cd" alt="Sublime's custom image"/>
</p>

# Как работает клиентское приложение
Базовый адрес используется localhost:7218 (указан в каждой View). В таблицах кнопка "Создать" делает запрос на создание нового элемента в БД. Кнопки "Обновить" и "Удалить" работают, когда вы выделяете конкретный элемент в таблице. Не получится редактировать все данные, а затем нажать на кнопку "Обновить", обновится только выделенный, а затем идет обновление всей таблицы.

# Текущие проблемы
Из проблем, так это в WPF после первой загрузки окна, некоторые элементы при повторной загрузке из БД обнуляются (а конкретнее в DataGridComboBoxColumn сбивается SelectedValue, т.е. ставится Null). Чтобы вновь видеть некоторые изменения, необходимо вновь открыть окно. На данный момент я не понял как их исправить
