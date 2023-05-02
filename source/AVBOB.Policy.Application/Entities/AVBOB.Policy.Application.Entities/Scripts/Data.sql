USE [AVBOB.Policy.Application]
GO
SET IDENTITY_INSERT [dbo].[DocumentType] ON 
GO
INSERT [dbo].[DocumentType] ([Id], [Description], [iOrder], [Guid], [IsActive], [DateCreated]) VALUES (1, N'Policy Application Form', 1, N'a1d1b553-2b91-48e9-bce9-ee1be4a074c2', 1, CAST(N'2023-05-01T11:33:26.570' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[DocumentType] OFF
GO
SET IDENTITY_INSERT [dbo].[PolicyType] ON 
GO
INSERT [dbo].[PolicyType] ([Id], [Description], [IsActive], [DateCreated]) VALUES (1, N'Policy 1', 1, CAST(N'2023-05-01T11:33:52.840' AS DateTime))
GO
INSERT [dbo].[PolicyType] ([Id], [Description], [IsActive], [DateCreated]) VALUES (2, N'Policy 2', 1, CAST(N'2023-05-01T11:33:59.153' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[PolicyType] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 
GO
INSERT [dbo].[Gender] ([Id], [Description], [IsActive], [DateCreated]) VALUES (1, N'Male', 1, CAST(N'2023-05-01T11:33:38.610' AS DateTime))
GO
INSERT [dbo].[Gender] ([Id], [Description], [IsActive], [DateCreated]) VALUES (2, N'Female', 1, CAST(N'2023-05-01T11:33:41.257' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
