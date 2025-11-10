INSERT INTO CategoryProducts (Title, Desciption, Image, Slug, ParentId, IsActive, ShowMenu)
VALUES 
-- 1. Danh mục cha
(N'Cà phê', N'Danh mục các loại cà phê', '/images/cafe.jpg', 'ca-phe', NULL, 1, 1),

-- 2. Danh mục con của Cà phê
(N'Cà phê hạt', N'Hạt cà phê rang xay', '/images/cafe-hat.jpg', 'ca-phe-hat', 1, 1, 1),

-- 3. Danh mục con của Cà phê
(N'Cà phê pha máy', N'Sản phẩm cà phê pha máy', '/images/cafe-may.jpg', 'ca-phe-pha-may', 1, 1, 1),

-- 4. Danh mục cha khác
(N'Trà', N'Các loại trà thiên nhiên', '/images/tra.jpg', 'tra', NULL, 1, 0),

-- 5. Danh mục con của Trà
(N'Trà đào', N'Trà đào tươi mát', '/images/tra-dao.jpg', 'tra-dao', 4, 1, 1);



INSERT INTO Members (Name, Image, Department, CreatedAt, [Order], IsActive, ShowWeb)
VALUES
(N'Giới thiệu công ty', '/images/about.jpg', N'Công ty', GETDATE(), 1, 1, 1),

(N'Tầm nhìn & Sứ mệnh', '/images/vision.jpg', N'Công ty', GETDATE(), 2, 1, 1),

(N'Giá trị cốt lõi', '/images/values.jpg', N'Công ty', GETDATE(), 3, 1, 1),

(N'Đội ngũ lãnh đạo', '/images/team.jpg', N'Nhân sự', GETDATE(), 4, 1, 1),

(N'Tin tức nổi bật', '/images/news.jpg', N'Tin tức', GETDATE(), 5, 1, 1),

(N'Ưu đãi đặc biệt', '/images/promo.jpg', N'Marketing', GETDATE(), 6, 1, 1),

(N'Sản phẩm nổi bật', '/images/product-hot.jpg', N'Sản phẩm', GETDATE(), 7, 1, 1),

(N'Đánh giá khách hàng', '/images/review.jpg', N'Khách hàng', GETDATE(), 8, 1, 1),

(N'Đối tác chiến lược', '/images/partner.jpg', N'Đối tác', GETDATE(), 9, 1, 1),

(N'Tuyển dụng', '/images/career.jpg', N'Nhân sự', GETDATE(), 10, 1, 1);




INSERT INTO Menus (Title, Slug, Url, ParentId, IsActive, CategoryNewsId)
VALUES
('Trang chủ', 'trang-chu', '/', NULL, 1, NULL),
('Giới thiệu', 'gioi-thieu', '/about', NULL, 1, NULL),
('Sản phẩm', 'san-pham', '/product', NULL, 1, NULL),
('Phân phối', 'phan-phoi', '/store', NULL, 1, NULL),
('Tin tức', 'tin-tuc', '/blog', NULL, 1, NULL),
('Liên hệ', 'lien-he', '/contact', NULL, 1, NULL),
('Gạo', 'gao', '/product/gao', 3, 1, NULL),
('Bột mì', 'bot-mi', '/product/bot-mi', 3, 1, NULL),
('Ngũ cốc', 'ngu-coc', '/product/ngu-coc', 3, 1, NULL);






INSERT INTO [News] (Title, Description, [View], Image, Author, Active, [Order], CreatedAt)
VALUES
('Giới thiệu công ty', 'Thông tin tổng quan về công ty và lĩnh vực hoạt động.', 120, '/images/news/1.jpg', 'Admin', 1, 1, GETDATE()),
('Sản phẩm mới ra mắt', 'Giới thiệu bộ sản phẩm mới nhất năm 2025.', 98, '/images/news/2.jpg', 'Admin', 1, 2, GETDATE()),
('Ưu đãi tháng 11', 'Khuyến mãi đặc biệt dành cho khách hàng thân thiết.', 211, '/images/news/3.jpg', 'Admin', 1, 3, GETDATE()),
('Quy trình sản xuất', 'Chia sẻ quy trình sản xuất hiện đại.', 85, '/images/news/4.jpg', 'Editor', 1, 4, GETDATE()),
('Tuyển dụng 2025', 'Tuyển dụng nhiều vị trí hấp dẫn.', 150, '/images/news/5.jpg', 'HR Dept', 1, 5, GETDATE()),
('Hợp tác chiến lược', 'Ký kết hợp tác với đối tác nước ngoài.', 176, '/images/news/6.jpg', 'Admin', 1, 6, GETDATE()),
('Sự kiện tri ân khách hàng', 'Chương trình tri ân diễn ra hằng năm.', 202, '/images/news/7.jpg', 'Marketing', 1, 7, GETDATE()),
('Công nghệ mới', 'Ứng dụng công nghệ mới vào sản xuất.', 315, '/images/news/8.jpg', 'Tech Dept', 1, 8, GETDATE()),
('Mở rộng nhà máy', 'Xây dựng nhà máy mới tại miền Nam.', 140, '/images/news/9.jpg', 'Admin', 1, 9, GETDATE()),
('Hoạt động từ thiện', 'Các hoạt động hỗ trợ cộng đồng.', 260, '/images/news/10.jpg', 'Admin', 1, 10, GETDATE()),
('Hướng dẫn sử dụng sản phẩm', 'Cách dùng đúng chuẩn.', 97, '/images/news/11.jpg', 'Editor', 1, 11, GETDATE()),
('Phản hồi khách hàng', 'Tổng hợp phản hồi tích cực.', 188, '/images/news/12.jpg', 'Marketing', 1, 12, GETDATE()),
('Định hướng phát triển', 'Chiến lược nâng cao chất lượng.', 205, '/images/news/13.jpg', 'Admin', 1, 13, GETDATE()),
('Báo cáo kinh doanh', 'Báo cáo quý III năm 2025.', 230, '/images/news/14.jpg', 'Finance', 1, 14, GETDATE()),
('Cập nhật nội bộ', 'Tin tức nội bộ dành cho nhân viên.', 75, '/images/news/15.jpg', 'HR Dept', 1, 15, GETDATE()),
('Giới thiệu sản phẩm nổi bật', 'Top sản phẩm bán chạy nhất.', 190, '/images/news/16.jpg', 'Admin', 1, 16, GETDATE()),
('Hướng dẫn bảo quản', 'Cách bảo quản sản phẩm tốt nhất.', 112, '/images/news/17.jpg', 'Editor', 1, 17, GETDATE()),
('Khách hàng tiêu biểu', 'Chân dung các khách hàng lớn.', 160, '/images/news/18.jpg', 'Marketing', 1, 18, GETDATE()),
('Bài viết chuyên môn', 'Thông tin chuyên sâu về ngành.', 134, '/images/news/19.jpg', 'Expert', 1, 19, GETDATE()),
('Hoạt động đào tạo', 'Khóa đào tạo kỹ năng mới cho nhân viên.', 178, '/images/news/20.jpg', 'HR Dept', 1, 20, GETDATE());



INSERT INTO NewsSections (NewsId, Title, Content, [Order]) VALUES
-- New 1
(1, 'Tổng quan', 'Giới thiệu chung về công ty.', 1),
(1, 'Sứ mệnh', 'Sứ mệnh phát triển bền vững.', 2),
(1, 'Tầm nhìn', 'Định hướng trở thành thương hiệu hàng đầu.', 3),

-- New 2
(2, 'Sản phẩm 1', 'Mô tả chi tiết sản phẩm đầu tiên.', 1),
(2, 'Sản phẩm 2', 'Thông tin sản phẩm tiếp theo.', 2),
(2, 'Công nghệ', 'Công nghệ sử dụng để sản xuất.', 3),

-- New 3
(3, 'Chương trình', 'Chi tiết ưu đãi tháng 11.', 1),
(3, 'Đối tượng', 'Áp dụng cho khách hàng thân thiết.', 2),
(3, 'Thời gian', 'Thời gian diễn ra chương trình.', 3),

-- New 4
(4, 'Quy trình', 'Quy trình sản xuất an toàn.', 1),
(4, 'Máy móc', 'Giới thiệu máy móc hiện đại.', 2),
(4, 'Kiểm định', 'Kiểm định chất lượng sản phẩm.', 3),

-- New 5
(5, 'Vị trí tuyển dụng', 'Các vị trí đang mở.', 1),
(5, 'Yêu cầu', 'Tiêu chí tuyển dụng.', 2),
(5, 'Quyền lợi', 'Quyền lợi hấp dẫn dành cho ứng viên.', 3),

-- New 6
(6, 'Đối tác', 'Thông tin đối tác chiến lược.', 1),
(6, 'Mục tiêu', 'Mục tiêu hợp tác.', 2),
(6, 'Lợi ích', 'Lợi ích cho hai bên.', 3),

-- New 7
(7, 'Sự kiện', 'Thông tin sự kiện tri ân.', 1),
(7, 'Khách mời', 'Danh sách khách mời đặc biệt.', 2),
(7, 'Hoạt động', 'Các hoạt động tại sự kiện.', 3),

-- New 8
(8, 'Công nghệ mới', 'Giới thiệu công nghệ mới áp dụng.', 1),
(8, 'Ưu điểm', 'Ưu điểm nổi bật.', 2),
(8, 'Ứng dụng', 'Ứng dụng vào quy trình sản xuất.', 3),

-- New 9
(9, 'Dự án', 'Thông tin dự án mở rộng.', 1),
(9, 'Vị trí', 'Vị trí nhà máy mới.', 2),
(9, 'Quy mô', 'Quy mô và sản lượng.', 3),

-- New 10
(10, 'Hoạt động', 'Chi tiết hoạt động từ thiện.', 1),
(10, 'Kết quả', 'Kết quả đạt được.', 2),
(10, 'Hình ảnh', 'Hình ảnh ghi lại sự kiện.', 3),

-- New 11
(11, 'Hướng dẫn', 'Hướng dẫn sử dụng cơ bản.', 1),
(11, 'Lưu ý', 'Những lưu ý quan trọng.', 2),
(11, 'Mẹo hay', 'Các mẹo hữu ích.', 3),

-- New 12
(12, 'Tổng hợp', 'Tổng hợp phản hồi khách hàng.', 1),
(12, 'Đánh giá', 'Các đánh giá chi tiết.', 2),
(12, 'Cải tiến', 'Định hướng cải tiến sản phẩm.', 3),

-- New 13
(13, 'Chiến lược', 'Chiến lược phát triển dài hạn.', 1),
(13, 'Định hướng', 'Định hướng cải tiến chất lượng.', 2),
(13, 'Mục tiêu', 'Mục tiêu trong thời gian tới.', 3),

-- New 14
(14, 'Doanh thu', 'Tổng quan doanh thu.', 1),
(14, 'Lợi nhuận', 'Phân tích lợi nhuận.', 2),
(14, 'Biểu đồ', 'Biểu đồ minh họa số liệu.', 3),

-- New 15
(15, 'Nội bộ', 'Thông báo nội bộ.', 1),
(15, 'Thông tin mới', 'Các thông tin cần lưu ý.', 2),
(15, 'Lịch họp', 'Lịch họp định kỳ.', 3),

-- New 16
(16, 'Sản phẩm nổi bật', 'Các sản phẩm bán chạy nhất.', 1),
(16, 'Thống kê', 'Thống kê doanh số.', 2),
(16, 'Lý do', 'Lý do được yêu thích.', 3),

-- New 17
(17, 'Bảo quản', 'Hướng dẫn bảo quản chi tiết.', 1),
(17, 'Lỗi thường gặp', 'Các lỗi bảo quản thường gặp.', 2),
(17, 'Khuyến nghị', 'Khuyến nghị sử dụng.', 3),

-- New 18
(18, 'Khách hàng', 'Khách hàng tiêu biểu.', 1),
(18, 'Hợp tác', 'Các dự án hợp tác nổi bật.', 2),
(18, 'Thành công', 'Câu chuyện thành công.', 3),

-- New 19
(19, 'Chuyên môn', 'Thông tin chuyên sâu.', 1),
(19, 'Phân tích', 'Phân tích kỹ thuật.', 2),
(19, 'Nhận định', 'Nhận định của chuyên gia.', 3),

-- New 20
(20, 'Đào tạo', 'Thông tin đào tạo nhân viên.', 1),
(20, 'Nội dung học', 'Các nội dung đào tạo.', 2),
(20, 'Kết quả', 'Đánh giá sau khóa học.', 3);



INSERT INTO Partners (Name, Image, Url, CreatedAt, [Order], IsActive, ShowWeb)
VALUES
('Đối tác A', '/images/partners/partner1.jpg', 'https://partnerA.com', GETDATE(), 1, 1, 1),
('Đối tác B', '/images/partners/partner2.jpg', 'https://partnerB.com', GETDATE(), 2, 1, 1),
('Đối tác C', '/images/partners/partner3.jpg', 'https://partnerC.com', GETDATE(), 3, 1, 1),
('Đối tác D', '/images/partners/partner4.jpg', 'https://partnerD.com', GETDATE(), 4, 1, 1),
('Đối tác E', '/images/partners/partner5.jpg', 'https://partnerE.com', GETDATE(), 5, 1, 1),
('Đối tác F', '/images/partners/partner6.jpg', 'https://partnerF.com', GETDATE(), 6, 1, 1),
('Đối tác G', '/images/partners/partner7.jpg', 'https://partnerG.com', GETDATE(), 7, 1, 1),
('Đối tác H', '/images/partners/partner8.jpg', 'https://partnerH.com', GETDATE(), 8, 1, 1),
('Đối tác I', '/images/partners/partner9.jpg', 'https://partnerI.com', GETDATE(), 9, 1, 1),
('Đối tác J', '/images/partners/partner10.jpg', 'https://partnerJ.com', GETDATE(), 10, 1, 1);



INSERT INTO Products (Image, Name, Price, SalePrice, Url, CateId, CreateDate, Description, Content, CategoryProductId)
VALUES
('/images/products/product1.jpg', 'Gạo thơm Jasmine', 20000, 18000, '/product/gao-jasmine', 1, GETDATE(), 'Gạo thơm cao cấp', 'Gạo thơm hạt dài, thích hợp nấu cơm', 1),
('/images/products/product2.jpg', 'Gạo ST25', 22000, 20000, '/product/gao-st25', 1, GETDATE(), 'Gạo ngon nổi tiếng', 'Gạo ST25 đạt giải gạo ngon nhất Việt Nam', 1),
('/images/products/product3.jpg', 'Gạo nếp cái hoa vàng', 25000, 23000, '/product/gao-nep', 1, GETDATE(), 'Gạo nếp thơm', 'Phù hợp làm xôi và bánh chưng', 1),
('/images/products/product4.jpg', 'Bột mì đa dụng', 18000, 16000, '/product/bot-mi-da-dung', 2, GETDATE(), 'Bột mì chất lượng', 'Sử dụng làm bánh, mì và các loại bột khác', 2),
('/images/products/product5.jpg', 'Bột mì số 8', 20000, 18000, '/product/bot-mi-so8', 2, GETDATE(), 'Bột mì số 8', 'Phù hợp làm bánh mì và các loại bánh ngọt', 2),
('/images/products/product6.jpg', 'Bột mì số 11', 21000, 19000, '/product/bot-mi-so11', 2, GETDATE(), 'Bột mì số 11', 'Bột mì giàu gluten, thích hợp bánh nướng', 2),
('/images/products/product7.jpg', 'Ngũ cốc yến mạch', 15000, 13000, '/product/ngu-coc-yen-mach', 3, GETDATE(), 'Ngũ cốc yến mạch nguyên hạt', 'Tốt cho sức khỏe, giàu chất xơ', 3),
('/images/products/product8.jpg', 'Ngũ cốc đa hạt', 18000, 16000, '/product/ngu-coc-da-hat', 3, GETDATE(), 'Ngũ cốc nhiều loại hạt', 'Nguyên liệu tự nhiên, thích hợp ăn sáng', 3),
('/images/products/product9.jpg', 'Ngũ cốc nguyên cám', 17000, 15000, '/product/ngu-coc-nguyen-cam', 3, GETDATE(), 'Ngũ cốc nguyên cám', 'Giữ nguyên chất dinh dưỡng, giàu chất xơ', 3),
('/images/products/product10.jpg', 'Bột gạo tẻ', 19000, 17000, '/product/bot-gao-te', 1, GETDATE(), 'Bột gạo tẻ mịn', 'Dùng làm bánh và nấu cháo', 1),
('/images/products/product11.jpg', 'Gạo lứt đỏ', 22000, 20000, '/product/gao-lut-do', 1, GETDATE(), 'Gạo lứt tốt cho sức khỏe', 'Giàu chất xơ, tốt cho người ăn kiêng', 1),
('/images/products/product12.jpg', 'Bột mì hữu cơ', 23000, 21000, '/product/bot-mi-huu-co', 2, GETDATE(), 'Bột mì hữu cơ', 'Không chất bảo quản, phù hợp làm bánh', 2),
('/images/products/product13.jpg', 'Ngũ cốc hạnh nhân', 25000, 23000, '/product/ngu-coc-hanh-nhan', 3, GETDATE(), 'Ngũ cốc kết hợp hạnh nhân', 'Ăn sáng dinh dưỡng', 3),
('/images/products/product14.jpg', 'Bột mì bánh mì', 20000, 18000, '/product/bot-mi-banh-mi', 2, GETDATE(), 'Bột mì làm bánh mì', 'Tỷ lệ gluten chuẩn', 2),
('/images/products/product15.jpg', 'Gạo tám xoan', 21000, 19000, '/product/gao-tam-xoan', 1, GETDATE(), 'Gạo thơm đặc sản', 'Hạt dài, mềm, thơm', 1),
('/images/products/product16.jpg', 'Bột mì số 13', 22000, 20000, '/product/bot-mi-so13', 2, GETDATE(), 'Bột mì đa dụng', 'Thích hợp làm bánh ngọt và bánh mì', 2),
('/images/products/product17.jpg', 'Ngũ cốc mix trái cây', 27000, 25000, '/product/ngu-coc-trai-cay', 3, GETDATE(), 'Ngũ cốc kết hợp trái cây sấy', 'Ăn sáng tiện lợi', 3),
('/images/products/product18.jpg', 'Gạo Bắc Hương', 23000, 21000, '/product/gao-bac-huong', 1, GETDATE(), 'Gạo thơm hạt dài', 'Cơm dẻo và thơm', 1),
('/images/products/product19.jpg', 'Bột mì số 10', 21000, 19000, '/product/bot-mi-so10', 2, GETDATE(), 'Bột mì đa dụng', 'Thích hợp làm bánh ngọt', 2),
('/images/products/product20.jpg', 'Ngũ cốc dinh dưỡng', 26000, 24000, '/product/ngu-coc-dinh-duong', 3, GETDATE(), 'Ngũ cốc dinh dưỡng cao', 'Phù hợp ăn sáng và giảm cân', 3),
('/images/products/product21.jpg', 'Gạo Hương Lài', 24000, 22000, '/product/gao-huong-lai', 1, GETDATE(), 'Gạo thơm đặc sản', 'Cơm mềm, hạt dài', 1),
('/images/products/product22.jpg', 'Bột mì số 9', 20000, 18000, '/product/bot-mi-so9', 2, GETDATE(), 'Bột mì đa dụng', 'Làm bánh mì và bánh ngọt', 2),
('/images/products/product23.jpg', 'Ngũ cốc yến mạch mix', 27000, 25000, '/product/ngu-coc-yen-mach-mix', 3, GETDATE(), 'Ngũ cốc yến mạch kết hợp hạt', 'Ăn sáng dinh dưỡng', 3),
('/images/products/product24.jpg', 'Gạo thơm Đài Loan', 25000, 23000, '/product/gao-thom-dai-loan', 1, GETDATE(), 'Gạo thơm nhập khẩu', 'Cơm mềm và thơm', 1),
('/images/products/product25.jpg', 'Bột mì hữu cơ số 11', 23000, 21000, '/product/bot-mi-huu-co-so11', 2, GETDATE(), 'Bột mì hữu cơ', 'An toàn cho bánh', 2),
('/images/products/product26.jpg', 'Ngũ cốc hạt chia', 28000, 26000, '/product/ngu-coc-hat-chia', 3, GETDATE(), 'Ngũ cốc bổ sung hạt chia', 'Tốt cho sức khỏe', 3),
('/images/products/product27.jpg', 'Gạo nếp Hương Việt', 26000, 24000, '/product/gao-nep-huong-viet', 1, GETDATE(), 'Gạo nếp thơm ngon', 'Phù hợp làm xôi', 1),
('/images/products/product28.jpg', 'Bột mì bánh ngọt', 22000, 20000, '/product/bot-mi-banh-ngot', 2, GETDATE(), 'Bột mì chuyên dụng', 'Làm bánh ngọt', 2),
('/images/products/product29.jpg', 'Ngũ cốc hạt điều', 30000, 28000, '/product/ngu-coc-hat-dieu', 3, GETDATE(), 'Ngũ cốc kết hợp hạt điều', 'Ăn sáng bổ dưỡng', 3),
('/images/products/product30.jpg', 'Gạo Japonica', 24000, 22000, '/product/gao-japonica', 1, GETDATE(), 'Gạo hạt tròn Nhật Bản', 'Cơm dẻo và ngon', 1),
('/images/products/product31.jpg', 'Bột mì số 7', 20000, 18000, '/product/bot-mi-so7', 2, GETDATE(), 'Bột mì đa dụng', 'Phù hợp làm bánh', 2),
('/images/products/product32.jpg', 'Ngũ cốc yến mạch nguyên cám', 26000, 24000, '/product/ngu-coc-yen-mach-nguyen-cam', 3, GETDATE(), 'Ngũ cốc nguyên cám', 'Tốt cho sức khỏe', 3),
('/images/products/product33.jpg', 'Gạo thơm nếp cẩm', 25000, 23000, '/product/gao-nep-cam', 1, GETDATE(), 'Gạo nếp thơm', 'Dùng làm xôi, bánh', 1),
('/images/products/product34.jpg', 'Bột mì số 12', 22000, 20000, '/product/bot-mi-so12', 2, GETDATE(), 'Bột mì chất lượng cao', 'Làm bánh mì và bánh ngọt', 2),
('/images/products/product35.jpg', 'Ngũ cốc mix hạt', 28000, 26000, '/product/ngu-coc-mix-hat', 3, GETDATE(), 'Ngũ cốc mix nhiều loại hạt', 'Ăn sáng tiện lợi', 3),
('/images/products/product36.jpg', 'Gạo lứt đen', 26000, 24000, '/product/gao-lut-den', 1, GETDATE(), 'Gạo lứt đen giàu dinh dưỡng', 'Ăn giảm cân, giàu chất xơ', 1),
('/images/products/product37.jpg', 'Bột mì số 6', 20000, 18000, '/product/bot-mi-so6', 2, GETDATE(), 'Bột mì đa dụng', 'Làm bánh ngọt và bánh mì', 2),
('/images/products/product38.jpg', 'Ngũ cốc hạnh nhân mix', 30000, 28000, '/product/ngu-coc-hanh-nhan-mix', 3, GETDATE(), 'Ngũ cốc kết hợp hạnh nhân và hạt', 'Ăn sáng bổ dưỡng', 3),
('/images/products/product39.jpg', 'Gạo thơm lài', 25000, 23000, '/product/gao-thom-lai', 1, GETDATE(), 'Gạo thơm đặc sản', 'Cơm mềm và thơm', 1),
('/images/products/product40.jpg', 'Bột mì số 5', 20000, 18000, '/product/bot-mi-so5', 2, GETDATE(), 'Bột mì đa dụng', 'Dùng làm bánh', 2),
('/images/products/product41.jpg', 'Ngũ cốc mix trái cây sấy', 30000, 28000, '/product/ngu-coc-trai-cay-say', 3, GETDATE(), 'Ngũ cốc kết hợp trái cây sấy', 'Ăn sáng tiện lợi', 3),
('/images/products/product42.jpg', 'Gạo Hương Lài đặc biệt', 26000, 24000, '/product/gao-huong-lai-dac-biet', 1, GETDATE(), 'Gạo thơm ngon cao cấp', 'Cơm mềm, dẻo', 1),
('/images/products/product43.jpg', 'Bột mì số 4', 20000, 18000, '/product/bot-mi-so4', 2, GETDATE(), 'Bột mì đa dụng', 'Làm bánh ngọt và bánh mì', 2),
('/images/products/product44.jpg', 'Ngũ cốc yến mạch mix trái cây', 30000, 28000, '/product/ngu-coc-yen-mach-trai-cay', 3, GETDATE(), 'Ngũ cốc mix trái cây', 'Ăn sáng bổ dưỡng', 3),
('/images/products/product45.jpg', 'Gạo nếp cẩm đặc sản', 27000, 25000, '/product/gao-nep-cam-dac-san', 1, GETDATE(), 'Gạo nếp thơm ngon', 'Dùng làm xôi và bánh', 1),
('/images/products/product46.jpg', 'Bột mì số 3', 20000, 18000, '/product/bot-mi-so3', 2, GETDATE(), 'Bột mì chất lượng', 'Làm bánh', 2),
('/images/products/product47.jpg', 'Ngũ cốc mix hạt dinh dưỡng', 32000, 30000, '/product/ngu-coc-mix-hat-dinh-duong', 3, GETDATE(), 'Ngũ cốc nhiều loại hạt', 'Ăn sáng bổ dưỡng', 3),
('/images/products/product48.jpg', 'Gạo thơm Thái Lan', 28000, 26000, '/product/gao-thom-thai-lan', 1, GETDATE(), 'Gạo thơm nhập khẩu', 'Cơm mềm và thơm', 1),
('/images/products/product49.jpg', 'Bột mì số 2', 20000, 18000, '/product/bot-mi-so2', 2, GETDATE(), 'Bột mì chất lượng', 'Dùng làm bánh', 2),
('/images/products/product50.jpg', 'Ngũ cốc mix ngũ hạt', 33000, 31000, '/product/ngu-coc-mix-ngu-hat', 3, GETDATE(), 'Ngũ cốc dinh dưỡng', 'Ăn sáng tiện lợi', 3);
