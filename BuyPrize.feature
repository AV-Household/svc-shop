Feature: BuyPrize

A short summary of the feature

@BuyPrize
Scenario: Ребенок может купить приз
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
		| son@family.com    | +79180000004 | Сын  | нет   |
	And в систему зашел Сын
	When пользователь покупает Шоколадка(Фирма Milka, 70)
	And сервис отвечает, что баллов достаточно
	Then удалить приз Шоколадка(Фирма Milka, 70)
	And сказать сервису уменьшить коичество баллов на 70


	Scenario: Родитель не может купить приз
	Given Список из
		| Name      | Description | Cost |
		| Шоколадка | Фирма Milka | 70   |
	And Семья из 
		| Email             | Phone        | Name | Adult |
        | father@family.com | +79180000001 | Папа | да    |
		| son@family.com    | +79180000004 | Сын  | нет   |
	And в систему зашел Папа
	When пользователь покупает Шоколадка(Фирма Milka, 70)
	And сервис отвечает, что баллов не достаточно
	Then в списке есть Шоколадка(Фирма Milka, 70)

