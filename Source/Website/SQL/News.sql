
USE [ImageGlassContext-de80e5ed-366d-4798-9f02-0098d31c9968]
GO

/****** Object: Table [dbo].[News] Script Date: 3/26/2022 8:24:55 PM ******/


SET QUOTED_IDENTIFIER OFF
GO

SET IDENTITY_INSERT [News] ON


INSERT INTO [News]
([Id], [Slug], [Title], [Image], [Description], [CustomContentUrl], [CreatedDate], [UpdatedDate], [Visible]) VALUES

(47, 'imageglass-3-0-9-2-is-released', 'ImageGlass 3.0.9.2 is released', 'https://cloud.githubusercontent.com/assets/3154213/9609181/dd984a3a-5104-11e5-8747-c52ae7f115aa.png', 'This release is a bugfix release, with many improvements and new features that requested by the users on Github. ', '', '2015-09-04 00:00:00', '2015-09-04 00:00:00', 1),
(48, 'imageglass-3-0-9-19-is-released', 'ImageGlass 3.0.9.19 is released', 'https://cloud.githubusercontent.com/assets/3154213/9609181/dd984a3a-5104-11e5-8747-c52ae7f115aa.png', 'Support HDR, EXR and SVG formats.', '', '2015-09-19 00:00:00', '2015-09-19 00:00:00', 1),
(49, 'imageglass-3-2-0-16-is-released', 'ImageGlass 3.2.0.16 is released', 'https://cloud.githubusercontent.com/assets/3154213/12851190/7e0a583a-cc63-11e5-8627-9b9ef483b9d8.png', 'Support WEBP (non-animated) formats.', '', '2016-02-06 00:00:00', '2016-02-06 00:00:00', 1),
(53, 'imageglass-3-5-9-17-is-released', 'ImageGlass 3.5.9.17 is released', 'https://cloud.githubusercontent.com/assets/3154213/18590815/d5831304-7c62-11e6-8946-5ef31dea1f0b.png', 'Ability to display thumbnails at right or left instead of bottom', '', '2016-09-18 10:37:00', '2016-09-18 10:37:00', 1),
(54, 'support-for-windows-xp-and-windows-vista-will-end-after-imageglass-4', 'Support for Windows XP and Windows Vista will end after ImageGlass 4', '', 'Due to end of support from Microsoft, Windows XP and Windows Vista will not be no longer supported since ImageGlass 5.', '', '2017-03-10 00:15:41', '2017-03-10 00:15:41', 1),
(57, 'new-with-the-imageglass-4-0', 'New with the ImageGlass 4.0', 'https://github.com/ImageGlass/config/blob/main/screenshots/v4.0/4.0_1.jpg?raw=true', 'ImageGlass keeps getting better - the version 4 includes new innovations, features and bug fixes. ', '', '2017-04-20 22:56:41', '2017-04-20 22:56:41', 1),
(58, 'imageGlass-4-1-is-released', 'ImageGlass 4.1 is released', 'https://github.com/ImageGlass/config/blob/main/screenshots/v4.0/4.0_1.jpg?raw=true', 'Improved thumbnail size in high-DPI screen. More thumbnail dimension options added.', '', '2017-07-26 00:06:07', '2017-07-26 00:06:07', 1),
(60, 'imageGlass-4-5-is-released', 'ImageGlass 4.5 is released', 'https://github.com/ImageGlass/config/blob/main/screenshots/v4.5/4.5_1.jpg?raw=true', 'This release mainly improves stability and features: RAW formats supported.', '', '2017-11-27 02:07:11', '2017-11-27 02:07:11', 1),
(61, 'how-to-set-ImageGlass-as-default-photo-viewer', 'How to set ImageGlass as default photo viewer', 'set-default-photo-viewer.jpg', 'This will help you open photos with one click.', '', '2017-12-02 11:35:16', '2017-12-02 11:35:16', 1),
(62, 'new-with-the-imageglass-5-0', 'New with the ImageGlass 5.0', 'https://github.com/ImageGlass/config/blob/main/screenshots/v5.0/5.0_1.jpg?raw=true', 'The version 5 includes new innovations, features and bug fixes: Color Picker tool, Customizable toolbar buttons', '', '2018-05-06 21:19:30', '2018-05-06 21:19:30', 1),
(63, 'announcing-imageglass-5-1', 'Announcing ImageGlass 5.1', 'https://github.com/ImageGlass/config/blob/main/screenshots/v5.0/5.0_1.jpg?raw=true', 'ImageGlass supports still HEIC image format. If you are upgrading from old version, you can manually add .heic extension in Settings > Files Associations list.', '', '2018-05-20 22:41:25', '2018-05-20 22:41:25', 1),
(64, 'announcing-imageglass-5-5', 'Announcing ImageGlass 5.5', 'https://github.com/ImageGlass/config/blob/main/screenshots/v5.5/5.5_1.jpg?raw=true', 'Introduce Zoom Modes, new Real-time Updating Engine, seamless Theme Enhancement and performance improvement.', '', '2018-07-29 18:34:49', '2018-07-29 18:34:49', 1),
(65, 'announcing-imageglass-6-0', 'Announcing ImageGlass 6.0', 'https://github.com/ImageGlass/config/blob/main/screenshots/v6.0/6.0_1.jpg?raw=true', 'Improved overall performance; equipped Color management settings, Full Screen mode, Navigation arrow buttons.', '', '2018-12-26 18:34:49', '2018-12-26 18:34:49', 1),
(66, 'critical-update-imageglass-6-0-12-29', 'Critical Update: ImageGlass 6.0.12.29', 'https://github.com/ImageGlass/config/blob/main/screenshots/v6.0/6.0_1.jpg?raw=true', 'Address some critical bugs reported; includes MSI builds', '', '2018-12-28 18:34:49', '2018-12-28 18:34:49', 1),
(67, 'announcing-imageglass-7-0', 'Announcing ImageGlass 7.0', 'https://github.com/ImageGlass/config/blob/main/screenshots/v7.0/7.0_1.jpg?raw=true', 'Introduce View color channels, Follow Windows File Explorer sort order, Cuztomise Zoom levels, improve ImageBooster', '', '2019-07-26 01:19:00', '2019-07-26 01:19:00', 1),
(68, 'announcing-imageglass-7-5', 'Announcing ImageGlass 7.5', 'https://github.com/ImageGlass/config/blob/main/screenshots/v7.5/7.5_1.jpg?raw=true', 'Introduce Frameless and Window fit mode; new setting engine, viewing multi-page format; touch gesture support; startup performance improvement.', '', '2020-01-05 14:46:00', '2020-01-01 14:48:00', 1),
(69, 'announcing-imageglass-7-6', 'Announcing ImageGlass 7.6 - 10th (❁´◡`❁)', 'https://github.com/ImageGlass/config/blob/main/screenshots/v7.6/7.6_1.jpg?raw=true', 'Adds Cropping tool; supports base64 image formats; playing slideshow in random interval; and lots of bug fixes.', '', '2020-04-29 15:18:56', '2020-04-29 14:48:00', 1),
(70, 'announcing-imageglass-8-0-kobe', 'Announcing ImageGlass 8.0 - Kobe', 'https://github.com/ImageGlass/config/blob/main/screenshots/v8.0/8.0_1.jpg?raw=true', 'Supports new image formats: AVIF, CR3, HEIF, JP2; Adds new EXIF tool; Able to customize toolbar button size', '', '2020-12-08 06:18:56', '2020-12-08 10:48:00', 1),
(71, 'announcing-imageglass-8-1-home', 'Announcing ImageGlass 8.1 - Home', 'https://github.com/ImageGlass/config/blob/main/screenshots/v8.1/8.1_1.jpg?raw=true', 'Supports new image formats JPEG XL, improves Exif tool, and lots of bug fixes.', '', '2021-04-17 16:26:48', '2021-04-17 10:48:00', 1),
(72, 'announcing-imageglass-8-2-june', 'Announcing ImageGlass 8.2 - June', 'https://github.com/ImageGlass/config/blob/main/screenshots/v8.2/8.2_1.jpg?raw=true', 'Improves viewing Ico, WebP, Avif formats; Prints multi-pages TIFF format and lot of bugfixes.', '', '2021-05-17 16:26:48', '2021-05-17 10:48:00', 1),
(73, 'announcing-imageglass-kobe-8-3', 'Announcing ImageGlass Kobe 8.3', 'https://github.com/ImageGlass/config/blob/main/screenshots/v8.3/8.3_1.jpg?raw=true', 'Updates UI for Windows 11, adds Custom zoom feature, improves multi-page formats.', '', '2021-11-21 12:23:24', '2021-11-21 10:48:00', 1),
(74, 'announcing-imageglass-kobe-8-5', 'Announcing ImageGlass Kobe 8.5', 'https://github.com/ImageGlass/config/blob/main/screenshots/v8.5/8.5_1.jpg?raw=true', 'Supports QOI image format, fixes bugs and improves stability.', '', '2022-01-22 12:23:24', '2022-01-22 10:48:00', 1);



SET IDENTITY_INSERT [News] OFF

