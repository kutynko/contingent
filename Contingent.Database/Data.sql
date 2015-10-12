﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

set IDENTITY_INSERT dbo.[Permissions] on

insert into dbo.[Permissions](Id, [Description]) values
	(1, N'View admin page'),
	(2, N'View students HR page'),
	(3, N'View auto mechanical faculty page'),
	(4, N'View engineering faculty page'),
	(5, N'View civil engineering faculty page'),
	(6, N'View economics page'),
	(7, N'View electrotechnical faculty page'),
	(8, N'View correspondence faculty page'),
	(9, N'View engineering and economics faculty page'),
	(10, N'View educational and methodical department page'),
	(11, N'Create proposals');

set IDENTITY_INSERT dbo.[Permissions] off
----------------------------------------
set IDENTITY_INSERT dbo.Users on

insert into dbo.Users(Id, Name, [Login], IsActive) values
	(1, N'Ruslan', 'minsk\ruslan_kutynko', 1);

set IDENTITY_INSERT dbo.Users off
----------------------------------------
set IDENTITY_INSERT dbo.Roles on

insert into dbo.Roles(Id, Name, [Description]) values
	(1, 'Admin', null);

set IDENTITY_INSERT dbo.Roles off
----------------------------------------
insert into dbo.Roles_2_Users values (1, 1);
----------------------------------------
insert into dbo.Permissions_2_Roles values (1, 1);


insert into dbo.Lookups(Id, [Description], TypeId) values
	(1, N'Назначение паспортных данных', 1),
	(2, N'Изменение паспортных данных', 1),
	(3, N'Подача документов абитуриентом', 1),
	(4, N'Зачислить как успешно сдавшего вступительные испытания', 1),
	(5, N'Перевести с другой специальности', 1),
	(6, N'Отчислить по академической неуспеваемости', 1),
	(7, N'Отчислить по собственному желанию', 1),
	(8, N'Перевести из другого учебного заведения', 1),
	(9, N'Восстановить', 1),
	(10, N'Отчислить в порядке перевода', 1),
	(11, N'Академический отпуск', 1),
	(20, N'Бюджетное обучение', 1),
	(21, N'Платное обучение (собственные)', 1),
	(22, N'Платное обучение (организация)', 1),
	(25, N'Бюджетное обучение -40%', 1),
	(26, N'Бюджетное обучение -60%', 1),
	(27, N'Бюджетное обучение -15%', 1),
	(28, N'Бюджетное обучение -20%', 1),
	(50, N'Заселить в общежитие', 1),
	(51, N'Выселить из общежития', 1),
	(100, N'Назначить стипендию', 1),
	(101, N'Отменить стипендию', 1),
	(200, N'Отпуск по уходу за ребенком до достижения им возраста трех лет', 1),
	(201, N'Отпуск для прохождения воинской службы', 1),
	(202, N'Академический отпуск в связи с призывом на службу в резерве', 1),
	(203, N'Отчислить за систематическое неисполнение обязанностей студента', 1),
	(204, N'Академический отпуск по медицинским показаниям', 1),
	(205, N'Расторгнуть договор о подготовке специалиста', 1),
	(206, N'Заключить договор о подготовке специалиста', 1),
	(207, N'Отчислить за привлечение к уголовной ответсвенности', 1),
	(208, N'Отчислить, как непрошедшего итоговую аттестацию без уважительных причин', 1),
	(209, N'Установить срок ликвидации разницы в учебных планах', 1),
	(210, N'Возвратить из академического отпуска', 1),
	(211, N'Назначить именную стипендию', 1),
	(212, N'Наложить взыскание', 1),
	(213, N'Продление академического отпуска', 1),
	(214, N'Снять оплату за проживаине в общежитии', 1),
	(215, N'Зачислить на государственное обеспечение', 1),
	(216, N'Снять с государственного обеспечения', 1),
	(217, N'Выплатить на ежегодное поплнение (на приобретение одежды, обуви)', 1),
	(218, N'Назначить оплату за проживаине в общежитии', 1),
	(219, N'Перевести в другое учебное заведение', 1),
	(220, N'Возвратить из  отпуска', 1),
	(1, N'Заявление', 2),
	(2, N'Представление', 2),
	(3, N'Справка', 2),
	(4, N'Удостоверение', 2),
	(5, N'Копия военного билета', 2),
	(6, N'Предписание', 2),
	(7, N'Согласие декана', 2),
	(8, N'Согласие деканов', 2),
	(9, N'Согласие родителей', 2),
	(10, N'Копия свидетельства о заключении брака', 2),
	(11, N'Договор', 2),
	(12, N'Повестка', 2),
	(13, N'Копия свидетельства о рассторжении брака', 2),
	(14, N'Копия свидетельства о рождении ребенка', 2),
	(15, N'Объяснительная', 2),
	(16, N'Подтверждение о трудоустройстве', 2),
	(17, N'Заключение ВКК', 2),
	(18, N'Аттестат', 2),
	(19, N'Докладная записка воспитателя', 2),
	(20, N'Копия свидетельства о перемене имени/фамилии/отчества', 2),
	(21, N'Копия удостоверения инвалида', 2),
	(22, N'Копия удостоверения пострадавшего от катастрофы на чернобыльской АЭС', 2),
	(23, N'Копия трудовой книжки', 2),
	(24, N'Медицинское заключение', 2),
	(25, N'Медицинская справка установленного образца', 2),
	(26, N'Оригинал документов о среднем образовании', 2),
	(27, N'Письмо учреждения', 2),
	(28, N'Письмо организации (предприятия)', 2),
	(29, N'Постановление Совета Министров РБ о государственном обеспечении детей-сирот, детей, оставшихся без попечения родителй', 2),
	(30, N'Представление декана', 2),
	(31, N'Справка об обучении', 2),
	(32, N'Докладная записка', 2),
	(33, N'Больничный лист', 2),
	(34, N'Справка из воинской части', 2),
	(35, N'Отсрочка прохождения воинской службы', 2);
