 --Usuario Juan
 -- +-- Familia "Administrador"
 --       +-- Patente "Agregar Usuario"
 --       +-- Patente "Eliminar Usuario"
 --+-- Familia "Reportes"
 --       +-- Patente "Ver Reportes"
 --       +-- Patente "Exportar PDF"

		--select * from family
		--select * from family_patent
		--select * from patent
		--select * from user_family
		
		--exec USER_SELECT_FAMILIES 1

		--exec family_select_patents 1

		--exec family_select_families 1

		insert into family values
		('Admin','Administrator')
		--('ChildFamilyTest1','ChildFamilyTest1Description')

		insert into patent values
		('User.Form','Access form User Management'),
		('User.Create','Create User')
		--('ChildFamilyTest1Patent','ChildFamilyTest1PatentDesc')

		insert into family_patent values
		(1,1),
		(1,2)

		insert into user_family values
		(1,1)


		--test family-family
		insert into family values
		('ChildFamilyTest1','ChildFamilyTest1Description')

		insert into patent values
		('ChildFamilyTest1Patent','ChildFamilyTest1PatentDesc')

		insert into family_patent values
		(2,3)

		insert into family_family values
		(1,2)

		----test familia de familia de familia	
		--select * from family
		insert into family values
		('ChildFamilyTest2','ChildFamilyTest2Description')

		--select * from patent
		insert into patent values
		('ChildFamilyTest2Patent','ChildFamilyTest2PatentDesc')

		--select * from family_patent
		insert into family_patent values
		(3,4)

		
		insert into family_family values
		(2,3)

		--select * from family_family
		--nota: child_id es la familia hija











