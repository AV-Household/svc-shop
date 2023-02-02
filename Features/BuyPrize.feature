Feature: BuyPrize

A short summary of the feature

@BuyPrize
Scenario: Ребенок может купить приз
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | 1     |
		| son@family.com    | +79180000004 | Сын  | 0     |
	And в систему зашел Сын
	And у пользователя не менее 70 баллов
	When пользователь покупает Шоколадка(Фирма Milka, 70)
	And сервис отвечает: баллов достаточно
	Then удалить приз Шоколадка(Фирма Milka, 70)
	And уменьшить коичество баллов на 70


	Scenario: Родитель не может купить приз
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | 1     |
		| son@family.com    | +79180000004 | Сын  | 0     |
	And в систему зашел Папа
	When пользователь покупает Шоколадка(Фирма Milka, 70)
	And сервис отвечает: магазин только для детей
	Then в списке есть приз Шоколадка(Фирма Milka, 70)

