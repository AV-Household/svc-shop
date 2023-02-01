Feature: Изменение описания приза 

A short summary of the feature

@EditPrize
Scenario: Родитель может изменить описание приза
	Given Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
	And в систему зашел Папа
	When Пользователь изменяет описание Шоколадка(Фирма Аленка)
	And Пользователь получает список призов
	Then в списке есть приз Шоколадка(Фирма Аленка)


	Scenario: Ребенок не может изменить описание приза
	Given Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
		| son@family.com    | +79180000004 | Сын  | нет   |
	And в систему зашел Сын
	When Пользователь изменяет описание Шоколадка(Фирма Аленка)
	And Пользователь получает список призов
	Then в списке есть приз Шоколадка(Фирма Milka)


Scenario: Родитель может изменить стоимость приза
	Given Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
	And в систему зашел Папа
	When Пользователь изменяет описание Шоколадка(50)
	And Пользователь получает список призов
	Then в списке есть приз Шоколадка(50)


	Scenario: Ребенок не может изменить стоимость приза
	Given Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
		| son@family.com    | +79180000004 | Сын  | нет   |
	And в систему зашел Сын
	When Пользователь изменяет описание Шоколадка(50)
	And Пользователь получает список призов
	Then в списке есть приз Шоколадка(70)