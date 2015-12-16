# README #

Novo Bridgefall, usando Unity 5, para Android.

Sistema de interface melhorado.
Sistemas de controle e script otimizados.
Usando Google Play SDK para Unity.

**--- Novos incrementos ---** 

Gamificação Bridgefall

	Maçã verde, funciona como vida.
	Jogador com 0 vidas não pode jogar uma fase, só o survival
		Muitos achieviments sobre passar fases, conseguir estrelas em fase e ganhar colecionáveis 
                       (itens para a coleção na sala de troféus)
		
	Assistir ads ganha 3 maçãs
	Compartilhar nas mídias sociais = 5 maçã
	X pontos (algo como 5 carinhas no nível 10) = 1 vida
	(pode comprar x maçãs com grana, talvez)

Modo Survival

Velocidade dos carinhas, (0.1,0.2, .., 1.5) * Nível
Vento:	Nada a lento		= 	Nível(1 - 3)
		lento a Médio		= 	Nível(4 - 6)
		Médio a Rápido	= 	Nível(7 - 9)
		Rápido a Muito	=	Nível(10)
Barco:	        Nada	        =       Nível(1 - 3)
		lento		= 	Nível(4 - 6)
		Médio		= 	Nível(7 - 9)
		Rápido	        =	Nível(10)
Chance de rebatedor:	        Nível *0.05%
Tempo para mudar o vento:	11-nível segundos direção; 1+nível Velocidade.