[![wakatime](https://wakatime.com/badge/user/018ba518-681f-4096-b18a-c08885d13001/project/018e804b-e676-4b1b-beab-6a37d39bdba3.svg)](https://wakatime.com/badge/user/018ba518-681f-4096-b18a-c08885d13001/project/018e804b-e676-4b1b-beab-6a37d39bdba3)

# Тестовое задание на стажировку OCS

### Постановка задачи
Необходимо реализовать прототип сервиса для сбора заявок на выступление для IT конференции. 

### Заявка представляет собой следующие данные:

- идентификатор пользователя / автора заявки - Guid, обязателен
- тип активности - одно значение из перечисления (доклад, мастеркласс, дискуссия), обязателен
- название - строка, до 100 символов, обязательное
- краткое описание для сайта - строка, до 300 символов, не обязательное
- план - строка, до 1000 символов, обязателен

Сервис должен реализовывать следующие операции (контракты под катом):

- создание заявки
- редактирование заявки
- удаление заявки
- отправка заявки на рассмотрение программным комитетом
- получение заявок поданных после указанной даты
- получение заявок не поданных и старше определенной даты
- получение текущей не поданной заявки для указанного пользователя
- получение заявки по идентификатору
- получение списка возможных типов активности

### Критерии приемки

- у пользователя может только одна не отправленная заявка (черновика заявки)
- нельзя создать заявку не указав идентификатор пользователя
- нельзя создать заявку не указав хотя бы еще одно поле помимо идентификатора пользователя
- нельзя отредактировать заявку так, чтобы  в ней не остались заполненными идентификатор пользователя + еще одно поле
- нельзя редактировать отправленные на рассмотрение заявки
- нельзя отменить / удалить заявки отправленные на рассмотрение
- нельзя удалить или редактировать не существующую заявку
- можно отправить на рассмотрение только заявки у которых заполнены все обязательные поля
- нельзя отправить на рассмотрение не существующую заявку
- запрос на получение поданных и не поданных заявок одновременно должен считаться не корректным

### Определение готовности

- сервис реализован в полном объеме согласно заданию
- критерии приемки выполняются
- сервис хранит свое состояние в базе данных и данные не теряются после рестарта
- схема базы данных описана в миграциях и автоматически разворачивается при старте сервиса
- написана инструкция по запуску сервиса
- сервис опубликован на GitHub в публичном репозитории, актуальная версия исходного кода в ветке мастер

### Архитектура

![](https://github.com/pulseneon/CFP/assets/87504288/99172760-7dc9-419a-b769-b31496a34b14)

### Запуск проекта
1. Клонируйте проект

```git clone https://github.com/pulseneon/CFP.git```

2. Запустите проект в docker

```docker-compose up --build```

3. Откройте в браузере swagger по пути:

```http://localhost:5065/swagger/index.html```
