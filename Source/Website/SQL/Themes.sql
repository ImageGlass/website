

USE [ImageGlassContext-de80e5ed-366d-4798-9f02-0098d31c9968]
GO

/****** Object: Table [dbo].[Themes] Script Date: 3/30/2022 11:16:55 PM ******/


SET QUOTED_IDENTIFIER OFF
GO

SET IDENTITY_INSERT [Themes] ON



INSERT INTO [Themes]
([Id], [Slug], [Title], [Link], [Image], [Description], [Version], [Compatibility], [Author], [Email], [Website], [Count], [CreatedDate], [UpdatedDate], [IsVisible], [IsDarkMode]) VALUES

(18, 'simple-grey-dark-toolbar', 'Simple Grey Dark Toolbar', 'Simple_Grey_Dark_Toolbar.igtheme', 'Simple_Grey_Dark_Toolbar.jpg', 'Simple grey icons with dark toolbar', '1.0', '2.0', 'Haris6AN', 'harissestan91@gmail.com', '', 6435, '2015-05-12 00:00:00', '2015-05-12 00:00:00', 1, 1),
(19, 'simple-grey-light-toolbar', 'Simple Grey Light Toolbar', 'Simple_Grey_Light_Toolbar.igtheme', 'Simple_Grey_Light_Toolbar.jpg', 'Simple grey icons with light toolbar', '2.0', '3.0', 'Haris6AN', 'harissestan91@gmail.com', '', 3860, '2015-12-28 00:00:00', '2015-12-28 00:00:00', 1, 0),
(20, 'white-and-grey', 'White & Grey', 'White_and_Grey.igtheme', 'white_and_grey.jpg', 'White icons on the grey background', '1.0', '3.0', 'Haris6AN', 'harissestan91@gmail.com', '', 4260, '2016-05-07 00:00:00', '2016-05-07 00:00:00', 1, 0),
(21, 'windows-10-blue', 'Windows 10', 'Windows10.igtheme', 'windows10.jpg', 'Windows 10 blue icons pack for ImageGlass toolbar.', '1.0', '1.4', 'Love Bdsobuj', 'love.bdsobuj@gmail.com', 'http://lovebdsobuj.com', 8746, '2016-09-24 12:01:00', '2016-09-24 12:01:00', 1, 1),
(22, 'simple-grey', 'Simple Grey', 'SimpleGrey.igtheme', 'SimpleGrey.jpg', 'Simple Grey icons made by Scnd101 (scnd101.deviantart.com) and used as ImageGlass theme icons.', '1.0', '3.0', 'Haris6AN', 'love.bdsobuj@gmail.com', 'harissestan91@gmail.com', 2155, '2017-01-09 12:01:00', '2017-01-09 12:01:00', 1, 0),
(23, '2017-light-gray', '2017 (Light Gray)', 'https://github.com/ImageGlass/theme/releases/download/8.3/2017-Light-Gray.Duong-Dieu-Phap.igtheme', '2017_light_gray.jpg', 'Modern line icons. Compatible with HDPI screen', '8.3', '8.0', '@ImageGlass', 'phap@imageglass.org', 'www.imageglass.org', 4667, '2018-05-08 20:24:35', '2020-12-07 17:04:29', 1, 0),

(24, 'material-light', 'Material Light', 'https://github.com/marnick-s/material-imageglass-themes/releases/download/v2.1/material_light_v2.1.zip', 'Material_Light_1.jpg', 'Material Light theme', '2.1', '7.6', 'SheepyDev', 'marnickschaap@gmail.com', '', 6302, '2017-12-10 20:24:35', '2018-12-27 20:24:35', 1, 0),
(25, 'material-dark', 'Material Dark', 'https://github.com/marnick-s/material-imageglass-themes/releases/download/v2.1/material_dark_v2.1.zip', 'Material_Dark_1.jpg', 'Material Dark theme', '2.1', '7.6', 'SheepyDev', 'marnickschaap@gmail.com', '', 14578, '2017-12-10 20:38:42', '2018-12-27 20:38:42', 1, 1),
(26, 'green-gradient', 'Green Gradient', 'https://github.com/ImageGlass/theme/releases/download/8.2/Green-Gradient.Duong-Dieu-Phap.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/dark/Green-Gradient.Duong-Dieu-Phap/preview.jpg', 'Green Gradient', '4.0', '8.2', 'Duong Dieu Phap', '', '', 17844, '2018-08-03 10:31:42', '2021-08-08 07:09:06', 1, 1),
(27, 'windows-10-dark', 'Windows 10 Dark', 'https://github.com/ImageGlass/theme/releases/download/8.3/Windows-10-Dark.Denis-Velikanov.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/dark/Windows-10-Dark.Denis-Velikanov/preview.png', 'Theme for the program ImageGlass in the style of Windows 10 based on the “Segoe MDL2 Assets” icons.', '3.7', '8.1', 'Denis Velikanov', 'In-bono-veritas@yandex.ru', 'https://www.deviantart.com/dehncka', 96963, '2018-08-21 22:19:11', '2021-11-23 03:30:11', 1, 1),

(28, 'icon8-office-light-gray', 'Icon8 Office (Light Gray)', 'https://github.com/ImageGlass/theme/releases/download/8.0/Icon8.Office16.Light.Gray.igtheme', 'icon8_office_light_gray.jpg', 'Office icon style from Icon8', '3.0', '8.0', 'Duong Dieu Phap', '', '', 3746, '2018-09-21 02:07:11', '2020-12-08 03:28:53', 1, 0),
(29, 'icon8-office-dark', 'Icon8 Office (Dark)', 'https://github.com/ImageGlass/theme/releases/download/8.0/Icon8.Office16.Dark.igtheme', 'icon8_office_dark.jpg', 'Office icon style from Icon8', '3.0', '8.0', 'Duong Dieu Phap', '', '', 8217, '2018-09-21 01:07:11', '2020-12-08 03:27:35', 1, 1),
(30, 'icon8-office-light-blue', 'Icon8 Office (Light Blue)', 'https://github.com/ImageGlass/theme/releases/download/8.0/Icon8.Office16.Light.Blue.igtheme', 'icon8_office_light_blue.jpg', 'Office icon style from Icon8', '3.0', '8.0', 'Duong Dieu Phap', '', '', 4440, '2018-09-21 02:17:11', '2020-12-08 00:50:23', 1, 0),

(33, 'windows-10-light', 'Windows 10 Light ', 'https://github.com/ImageGlass/theme/releases/download/8.3/Windows-10-Light.Denis-Velikanov.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/light/Windows-10-Light.Denis-Velikanov/preview.png', 'Theme for the program ImageGlass in the style of Windows 10 based on the “Segoe MDL2 Assets” icons.', '3.7', '8.1', 'Denis Velikanov', 'In-bono-veritas@yandex.ru', 'https://www.deviantart.com/dehncka', 21635, '2019-08-15 14:23:23', '2021-11-23 03:31:04', 1, 0),
(34, 'windows-10-navy-blue', 'Windows 10 Navy Blue', 'https://github.com/ImageGlass/theme/releases/download/8.3/Windows-10-Navy-Blue.Denis-Velikanov.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/dark/Windows-10-Navy-Blue.Denis-Velikanov/preview.png', 'Theme for the program ImageGlass in the style of Windows 10 based on the “Segoe MDL2 Assets” icons.', '3.7', '8.1', 'Denis Velikanov', 'In-bono-veritas@yandex.ru', 'https://www.deviantart.com/dehncka', 33200, '2019-08-15 14:49:40', '2021-11-23 03:31:34', 1, 1),


(37, '2017-ocean', '2017 (Ocean)', 'https://github.com/ImageGlass/theme/releases/download/8.0/2017.Ocean.igtheme', '2017_ocean.jpg', 'Modern line icons. Compatible with HDPI screen', '8.0', '8.0', '@ImageGlass', 'phap@imageglass.org', 'www.imageglass.org', 2623, '2020-12-07 20:24:35', '2020-12-07 21:04:29', 1, 1),
(38, 'line-gray', 'Line (Gray)', 'https://github.com/ImageGlass/theme/releases/download/8.3/Line-Gray.xkonglong.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/light/Line-Gray.xkonglong/preview%201.png', 'Line icon for ImageGlass.', '1.3', '8.3', '小恐龙', 'xkonglong@QQ.com', 'xkonglong.com', 3604, '2021-01-06 20:24:35', '2021-12-10 21:04:29', 1, 0),
(39, 'roka', 'Roka', 'https://github.com/ImageGlass/theme/releases/download/8.1/Roka.B-R.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/light/Roka.B-R/preview.jpg', 'An ImageGlass theme', '0.1', '8.1', 'B.R', 'brests@protonmail.com', '', 1508, '2021-04-24 20:24:35', '2021-04-21 11:38:55', 1, 0),
(40, 'windows-10-light-accent', 'Windows 10 Light Accent', 'https://github.com/ImageGlass/theme/releases/download/8.3/Windows-10-Light-Accent.Denis-Velikanov.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/light/Windows-10-Light-Accent.Denis-Velikanov/preview.png', 'Theme for the program ImageGlass in the style of Windows 10 based on the “Segoe MDL2 Assets” icons.', '3.7', '8.1', 'Denis Velikanov', 'In-bono-veritas@yandex.ru', 'https://www.deviantart.com/dehncka', 7896, '2021-05-14 14:49:40', '2021-11-23 11:59:14', 1, 0),
(41, 'colibre-infinity-20px', 'Colibre infinity 20px', 'https://github.com/ImageGlass/theme/releases/download/8.2/Colibre-20.Amir-H-Jahangard.igtheme', 'https://github.com/ImageGlass/theme/raw/8.2/themes/light/Colibre-20.Amir-H-Jahangard/preview%201.png', 'Clear office-like theme for ImageGlass in 20x20px scale-able SVGs', '2.0', '8.2', 'Amir H. Jahangard', 'iJahangard@outlook.com', '', 2512, '2021-06-18 14:49:40', '2021-06-18 11:59:14', 1, 0),
(42, 'colibre-infinity-24px', 'Colibre infinity 24px', 'https://github.com/ImageGlass/theme/releases/download/8.2/Colibre-24.Amir-H-Jahangard.igtheme', 'https://github.com/ImageGlass/theme/raw/8.2/themes/light/Colibre-24.Amir-H-Jahangard/colipre.png', 'Clear office-like theme for ImageGlass in 24x24px scale-able SVGs', '2.0', '8.2', 'Amir H. Jahangard', 'iJahangard@outlook.com', '', 2976, '2021-06-18 15:42:06', '2021-06-18 11:59:14', 1, 0),
(43, 'dracula', 'Dracula', 'https://github.com/dracula/imageglass/archive/master.zip', 'https://github.com/dracula/imageglass/raw/master/Dracula/preview.jpg', 'Dracula\r\ntheme for ImageGlass', '1.0', '8.2', 'Felkon', 'https://github.com/FelkonEx', 'https://draculatheme.com/imageglass', 5003, '2021-06-18 15:44:55', '2021-06-18 11:59:14', 1, 1),
(44, 'colibre-infinity-20px-dark-edit', 'Colibre infinity 20px (Dark edit)', 'https://github.com/ImageGlass/theme/releases/download/8.2/Colibre-20-Dark-Edit.Amir-H-Jahangard.igtheme', 'https://github.com/ImageGlass/theme/raw/master/themes/dark/Colibre-20-Dark-Edit.Amir-H-Jahangard/preview.jpg', 'Clear office-like theme for ImageGlass in 20x20px scale-able SVGs (In dark theme for who like)', '2.0', '8.2', 'Amir H. Jahangard (Edit by Sakenao Rinme)', 'iJahangard@outlook.com (piopopoooyu76@gmail.com)', '', 5378, '2021-08-08 14:49:40', '2021-08-08 11:59:14', 1, 1);

SET IDENTITY_INSERT [Themes] OFF
