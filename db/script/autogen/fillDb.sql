USE [Prizm]
GO
INSERT [dbo].[chemicalComposition] ([id], [isActive]) 
	VALUES (N'28643951-ddd8-4be3-9d0c-6f67138e5f6b', 1)
INSERT [dbo].[chemicalComposition] ([id], [isActive]) 
	VALUES (N'2af974b6-d290-4674-a01e-8c43075dd177', 1)
INSERT [dbo].[chemicalComposition] ([id], [isActive]) 
	VALUES (N'0c53dabe-8cd6-4308-806d-c844667d2fb4', 1)
INSERT [dbo].[chemicalComposition] ([id], [isActive]) 
	VALUES (N'b8039467-0dfd-4c7b-9c31-e6fdac58ce67', 1)
INSERT [dbo].[chemicalComposition] ([id], [isActive]) 
	VALUES (N'325fa31d-09e3-4ae5-9c67-ea64e5152f99', 1)


INSERT [dbo].[heat] ([id], [number], [steelGrade], [chemicalCompositionId], [isActive]) 
	VALUES (N'3da08c26-195a-4f49-842a-56388ff3e8c3', N'Плавка №1', N'H18N9T', N'2af974b6-d290-4674-a01e-8c43075dd177', 1)
INSERT [dbo].[heat] ([id], [number], [steelGrade], [chemicalCompositionId], [isActive]) 
	VALUES (N'f3eb5e92-ff6b-4678-a9f9-a490e39647c4', N'Плавка №2', N'SDHZFH', N'2af974b6-d290-4674-a01e-8c43075dd177', 1)
INSERT [dbo].[heat] ([id], [number], [steelGrade], [chemicalCompositionId], [isActive]) 
	VALUES (N'e2a3549f-4f19-4889-bfb7-d700c36afc0f', N'Плавка №3', N'FKLOOP', N'2af974b6-d290-4674-a01e-8c43075dd177', 1)


INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'881e860a-12a0-41ba-9156-0fbd1d13c4bd', N'1500 X 100500 X 50 - безшовный', 1)
INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'2891cb71-0c65-4335-89a1-1de6acd8f0d7', N'1000 X 100500 X 50 - спиралевидный', 1)
INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'c8990c64-7d25-4202-a059-aabd296dde42', N'1600 X 100500 X 50 - прямой', 1)
INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'cb242192-5b71-4e00-8683-cc5731dc2c90', N'1600 X 100500 X 50 - прямой', 1)
INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'e4106d19-5b72-4546-b7ff-d309c3339b3f', N'1500 X 100500 X 50 - безшовный', 1)
INSERT [dbo].[pipeMillSizeType] ([id], [type], [isActive]) 
	VALUES (N'1773f703-88a1-423f-ac18-f501d1073754', N'1000 X 100500 X 50 - спиралевидный', 1)


INSERT [dbo].[plate] ([id], [number], [thickness], [chemicalCompositionId], [heatId], [isActive]) 
	VALUES (N'c3c33041-c4d6-4455-94a7-3ca9e9c1019c', N'Лист № 1', 1500, N'0c53dabe-8cd6-4308-806d-c844667d2fb4', N'e2a3549f-4f19-4889-bfb7-d700c36afc0f', 1)
INSERT [dbo].[plate] ([id], [number], [thickness], [chemicalCompositionId], [heatId], [isActive]) 
	VALUES (N'4811290d-9c14-400c-927c-97e0672fcfad', N'Лист № 2', 1600, N'28643951-ddd8-4be3-9d0c-6f67138e5f6b', N'3da08c26-195a-4f49-842a-56388ff3e8c3', 1)
INSERT [dbo].[plate] ([id], [number], [thickness], [chemicalCompositionId], [heatId], [isActive]) 
	VALUES (N'3b20cdbb-5cfb-4a94-ba70-c0ab641566e5', N'Лист № 3', 1700, N'2af974b6-d290-4674-a01e-8c43075dd177', N'f3eb5e92-ff6b-4678-a9f9-a490e39647c4', 1)
INSERT [dbo].[plate] ([id], [number], [thickness], [chemicalCompositionId], [heatId], [isActive]) 
	VALUES (N'64778314-0995-4850-a35f-e41218dd8d98', N'Лист № 4', 1800, N'2af974b6-d290-4674-a01e-8c43075dd177', N'f3eb5e92-ff6b-4678-a9f9-a490e39647c4', 1)


INSERT [dbo].[purchaseOrder] ([id], [number], [date], [isActive]) 
	VALUES (N'75c2b639-95fe-43a6-b48d-596a69e53bb3', N'Наряд-заказ 1', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[purchaseOrder] ([id], [number], [date], [isActive]) 
	VALUES (N'dba4a12a-23fb-4447-a8ed-b098b5a1392b', N'Наряд-заказ 2', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[purchaseOrder] ([id], [number], [date], [isActive]) 
	VALUES (N'2b185e6e-dfbb-4240-a3a4-c8af0148cc18', N'Наряд-заказ 3', CAST(0x34390B00 AS Date), 1)


INSERT [dbo].[railcar] ([id], [number], [certificate], [destination], [shippingDate], [isActive]) 
	VALUES (N'7a4b865f-0cb2-47ec-bd45-85f2be55c556', N'Вагон - 1', N'Сертификат - 1', N'Стройка 3', CAST(0x1B390B00 AS Date), 1)
INSERT [dbo].[railcar] ([id], [number], [certificate], [destination], [shippingDate], [isActive]) 
	VALUES (N'affe50fd-f234-4cd3-9e07-ab6fe78f67cd', N'Вагон - 2', N'Сертификат - 3', N'Стройка 2', CAST(0xDC380B00 AS Date), 1)
INSERT [dbo].[railcar] ([id], [number], [certificate], [destination], [shippingDate], [isActive]) 
	VALUES (N'f9b47597-1270-4e62-8bde-e30b8c8756f6', N'Вагон - 3', N'Сертификат - 2', N'Стройка 1', CAST(0xDC380B00 AS Date), 1)


INSERT [dbo].[pipe] ([id], [wallThickness], [diameter], [weight], [mill], [date],[pipeMillStatus], [typeId], [plateId], [purchaseOrderId], [railcarId], [chemicalCompositionId], [length], [number], [isActive], [inspectionStatus], [constructionStatus]) VALUES 
(N'681ee872-c79f-4a0d-979d-636924c3516c', 60, 400, 12000, N'Завод 1', CAST(0x34390B00 AS Date), N'Produced', N'2891cb71-0c65-4335-89a1-1de6acd8f0d7', N'c3c33041-c4d6-4455-94a7-3ca9e9c1019c', N'75c2b639-95fe-43a6-b48d-596a69e53bb3', N'7a4b865f-0cb2-47ec-bd45-85f2be55c556', N'325fa31d-09e3-4ae5-9c67-ea64e5152f99', 10000, N'труба - 1', 1, NULL, NULL)

INSERT [dbo].[pipe] ([id], [wallThickness], [diameter], [weight], [mill], [date], [pipeMillStatus], [typeId], [plateId], [purchaseOrderId], [railcarId], [chemicalCompositionId], [length], [number], [isActive], [inspectionStatus], [constructionStatus]) VALUES 
(N'b20a4f5b-e578-491c-888b-914bdde9db09', 70, 500, 13000, N'Завод 2', CAST(0x34390B00 AS Date), N'Stocked', N'c8990c64-7d25-4202-a059-aabd296dde42', N'3b20cdbb-5cfb-4a94-ba70-c0ab641566e5', N'dba4a12a-23fb-4447-a8ed-b098b5a1392b', N'affe50fd-f234-4cd3-9e07-ab6fe78f67cd', N'0c53dabe-8cd6-4308-806d-c844667d2fb4', 30000, N'труба - 2', 1, NULL, NULL)

INSERT [dbo].[pipe] ([id], [wallThickness], [diameter], [weight], [mill], [date],[pipeMillStatus], [typeId], [plateId], [purchaseOrderId], [railcarId], [chemicalCompositionId], [length], [number], [isActive], [inspectionStatus], [constructionStatus]) VALUES 
(N'38fe21e2-c3ab-48e2-b92b-ba1ade4f2b88', 80, 600, 14000, N'Завод 3', CAST(0x34390B00 AS Date), N'Shipped', N'cb242192-5b71-4e00-8683-cc5731dc2c90', N'4811290d-9c14-400c-927c-97e0672fcfad', N'2b185e6e-dfbb-4240-a3a4-c8af0148cc18', N'7a4b865f-0cb2-47ec-bd45-85f2be55c556', N'b8039467-0dfd-4c7b-9c31-e6fdac58ce67', 20000, N'труба - 3', 0, NULL, NULL)


INSERT [dbo].[inspector] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [isActive]) 
	VALUES (N'c72b5130-8161-4ae0-bf18-639cc628670d', N'Василиса', N'Цацкина', N'Яковна', N'сертификат - 1', CAST(0xC5440B00 AS Date), 1)
INSERT [dbo].[inspector] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [isActive]) 
	VALUES (N'4d78636f-289b-4e42-86c4-f09929d14809', N'Василиса', N'Иванова', N'Анатольевна', N'сертификат - 2', CAST(0xEB410B00 AS Date), 1)
INSERT [dbo].[inspector] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [isActive]) 
	VALUES (N'fdb6fb79-4443-4678-8843-ffe5556ae6ff', N'Вячеслав', N'Блинов', N'Иванович', N'сертификат - 3', CAST(0x58430B00 AS Date), 1)


INSERT [dbo].[testResult] ([id], [date], [value], [status], [isActive]) 
	VALUES (N'8c93557a-d426-4674-abf2-068a4e4f7875', CAST(0x34390B00 AS Date), N'125', N'Принят', 1)
INSERT [dbo].[testResult] ([id], [date], [value], [status], [isActive]) 
	VALUES (N'd2a1e9c5-506a-48c5-a9c6-7aab908eccc6', CAST(0x34390B00 AS Date), N'321', N'Задержан', 1)
INSERT [dbo].[testResult] ([id], [date], [value], [status], [isActive]) 
	VALUES (N'b5ca4d84-caba-4fc6-bf98-8e69e036faad', CAST(0x34390B00 AS Date), N'0', N'Отклонен', 1)


INSERT [dbo].[testResult_inspector] ([id], [inspectorId], [resultId]) 
	VALUES (N'e5f0c133-8415-44ac-8e54-92198677ce6b', N'fdb6fb79-4443-4678-8843-ffe5556ae6ff', N'8c93557a-d426-4674-abf2-068a4e4f7875')
INSERT [dbo].[testResult_inspector] ([id], [inspectorId], [resultId]) 
	VALUES (N'a1a37443-37ab-4ac3-b832-a00dfed4fd65', N'c72b5130-8161-4ae0-bf18-639cc628670d', N'd2a1e9c5-506a-48c5-a9c6-7aab908eccc6')
INSERT [dbo].[testResult_inspector] ([id], [inspectorId], [resultId]) 
	VALUES (N'49587715-5470-4b44-a638-b989030b8133', N'4d78636f-289b-4e42-86c4-f09929d14809', N'b5ca4d84-caba-4fc6-bf98-8e69e036faad')


INSERT [dbo].[pipeTest] ([id], [code], [name], [testSubject], [controlType], [resultType], [minExpected], [maxExpected], [boolExpected], [isRequired], [pipeMillSizeTypeId], [isActive]) 
	VALUES (N'ac7c1f53-1c4c-4cbf-8959-140553dffda0', N'3.1', N'Наличие повреждеий', N'Изоляция', N'Review', N'String', NULL, NULL, 0, 1, N'881e860a-12a0-41ba-9156-0fbd1d13c4bd', 1)
INSERT [dbo].[pipeTest] ([id], [code], [name], [testSubject], [controlType], [resultType], [minExpected], [maxExpected], [boolExpected], [isRequired], [pipeMillSizeTypeId], [isActive]) 
	VALUES (N'adceb99c-226d-468a-91e4-2acf85683b1b', N'1.1', N'Измерение адгезии', N'Изоляция', N'Monitor', N'Boolean', CAST(20.00 AS Decimal(5, 2)), CAST(30.00 AS Decimal(5, 2)), 0, 1, N'2891cb71-0c65-4335-89a1-1de6acd8f0d7', 1)
INSERT [dbo].[pipeTest] ([id], [code], [name], [testSubject], [controlType], [resultType], [minExpected], [maxExpected], [boolExpected], [isRequired], [pipeMillSizeTypeId], [isActive]) 
	VALUES (N'08702dad-8ebd-427a-95af-5dd73375a2a0', N'2.1', N'Измерение адгезии', N'Изоляция', N'Monitor', N'String', CAST(30.00 AS Decimal(5, 2)), CAST(40.00 AS Decimal(5, 2)), 0, 0, N'c8990c64-7d25-4202-a059-aabd296dde42', 1)


INSERT [dbo].[pipeTestResult] ([id], [testResultId], [pipeId], [pipeTestId], [isActive]) 
	VALUES (N'92329598-67e7-489f-8328-844a2889d12a', N'b5ca4d84-caba-4fc6-bf98-8e69e036faad', N'b20a4f5b-e578-491c-888b-914bdde9db09', N'ac7c1f53-1c4c-4cbf-8959-140553dffda0', 1)
INSERT [dbo].[pipeTestResult] ([id], [testResultId], [pipeId], [pipeTestId], [isActive]) 
	VALUES (N'b6ee3e15-4601-4d9a-b60e-8f3136865c30', N'8c93557a-d426-4674-abf2-068a4e4f7875', N'681ee872-c79f-4a0d-979d-636924c3516c', N'adceb99c-226d-468a-91e4-2acf85683b1b', 1)
INSERT [dbo].[pipeTestResult] ([id], [testResultId], [pipeId], [pipeTestId], [isActive]) 
	VALUES (N'40a1afbe-d153-4574-b136-b65ea27fb304', N'd2a1e9c5-506a-48c5-a9c6-7aab908eccc6', N'38fe21e2-c3ab-48e2-b92b-ba1ade4f2b88', N'08702dad-8ebd-427a-95af-5dd73375a2a0', 1)


INSERT [dbo].[weld] ([id], [date], [isActive]) 
	VALUES (N'39715da5-20d3-465f-9746-075f5c8f6b7e', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[weld] ([id], [date], [isActive]) 
	VALUES (N'b0037b0a-6445-425e-b4c7-8e6e44225e09', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[weld] ([id], [date], [isActive]) 
	VALUES (N'b591f95b-9a5c-4160-938c-b6430fc43691', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[weld] ([id], [date], [isActive]) 
	VALUES (N'0f078781-5462-4424-9078-e596dcea7d16', CAST(0x34390B00 AS Date), 1)
INSERT [dbo].[weld] ([id], [date], [isActive]) 
	VALUES (N'6d925bf9-9334-4cc5-9ea6-efffc6106668', CAST(0x34390B00 AS Date), 1)


INSERT [dbo].[welder] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [stamp], [grade], [isActive]) 
	VALUES (N'7da1ef56-c5de-46a8-8298-167e17bf087a', N'Евлампий', N'Пупкин', N'Василиевич', N'Сертификат № 1', CAST(0x90400B00 AS Date), N'B - 33', 1, 1)
INSERT [dbo].[welder] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [stamp], [grade], [isActive]) 
	VALUES (N'9f61c6f5-2c8e-4f1b-babb-2a417a706b77', N'Виниамин', N'Петров', N'Орестович', N'Сертификат № 2', CAST(0x7A400B00 AS Date), N'B - 22', 1, 1)
INSERT [dbo].[welder] ([id], [firstName], [lastName], [middleName], [certificate], [certificateExpiration], [stamp], [grade], [isActive]) 
	VALUES (N'9179524c-6e50-4cdd-acc8-72232b2e3c58', N'Инокентий', N'Иванов', N'Варфоломеевич', N'Сертификат № 3', CAST(0xB63D0B00 AS Date), NULL, 1, 0)


INSERT [dbo].[weld_welder] ([id], [weldId], [welderId], [pipeId]) 
	VALUES (N'4264d19d-f7ec-4ac5-b310-d908d7358163', N'b0037b0a-6445-425e-b4c7-8e6e44225e09', N'9f61c6f5-2c8e-4f1b-babb-2a417a706b77', N'b20a4f5b-e578-491c-888b-914bdde9db09')
INSERT [dbo].[weld_welder] ([id], [weldId], [welderId], [pipeId]) 
	VALUES (N'de459542-ad1d-42a6-ad48-e20cd705a471', N'b591f95b-9a5c-4160-938c-b6430fc43691', N'9179524c-6e50-4cdd-acc8-72232b2e3c58', N'38fe21e2-c3ab-48e2-b92b-ba1ade4f2b88')
INSERT [dbo].[weld_welder] ([id], [weldId], [welderId], [pipeId]) 
VALUES (N'7d175178-3ff4-457d-8f94-f9890e2a415d', N'39715da5-20d3-465f-9746-075f5c8f6b7e', N'7da1ef56-c5de-46a8-8298-167e17bf087a', N'681ee872-c79f-4a0d-979d-636924c3516c')
