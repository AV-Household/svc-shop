Feature: Feature1

A short summary of the feature

@DeletePrize
Scenario: Родитель может удалить приз из списка
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka  | 70  |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | 1     |
	And в систему зашел Папа
	When Пользователь удаляет Шоколадка(Фирма Milka, 70)
	And Пользователь получает список призов
	Then количество элементов в списке призов 0
	And Отчистить список


Scenario: Ребенок не может удалить приз из списка
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka  | 70  |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | 1     |
		| son@family.com    | +79180000004 | Сын  | 0     |
	And в систему зашел Сын
	When Пользователь удаляет Шоколадка(Фирма Milka, 70)
	And Пользователь получает список призов
	Then количество элементов в списке призов 1	
	And Отчистить список


Scenario: Родитель не может удалить не существующий приз из списка
	Given Список из
		| Name      | Description  | Cost |
		| Шоколадка | Фирма Milka  | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | 1     |
	And в систему зашел Папа
	When Пользователь удаляет Мороженое(Maxibon, 90)
	And Пользователь получает список призов
	Then количество элементов в списке призов 1
	And Отчистить список