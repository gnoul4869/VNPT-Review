-- Admin & User ------------------------------------------------------------
INSERT INTO "AspNetRoles" VALUES(
    '01',
    'Admin',
    'ADMIN',
    '1bfa31f5-fc3b-46d7-9b73-61229aae58a9'
);
INSERT INTO "AspNetUserRoles" VALUES(
    '1ab1c6ec-51ee-47e9-8bde-dc1945e5c965',
    '01'
);
-- Office's Data ----------------------------------------------------------
INSERT INTO Office VALUES(
    '01',
    'Viễn Thông Bạc Liêu',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0100',
    'Phòng Nhân sự - Tổng hợp',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0101',
    'Phòng Kế toán - Kế hoạch',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0116',
    'Trung tâm Công nghệ thông tin',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0106',
    'Phòng Kỹ thuật - Đầu tư',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0115',
    'Trung Tâm Điều hành Thông tin',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '01151',
    'Tổ Khai thác',
    null,
    '0115',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '01152',
    'Tổ Kỹ thuật',
    null,
    '0115',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '02',
    'Trung Tâm Viễn Thông Bạc Liêu 1',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0112',
    'Tổ Kỹ thuật Bạc Liêu',
    '(Bạc Liêu, Cầu Kè, Đô Thị Mới)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0222',
    'Tổ Kỹ thuật Trà Kha',
    '(Cầu Sập, Trà Kha)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '1013',
    'Tổ Kỹ thuật Hiệp Thành',
    '(Hiệp Thành, Xiêm Cáng, Vĩnh Trạch)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '1014',
    'Tổ Kỹ thuật Cái Dày',
    '(Cái Dầy, Châu Thới, Châu Hưng A)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '1015',
    'Tổ Kỹ thuật Hưng Thành',
    '(Hưng Hội, Gia Hội)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10101',
    'Tổ Kỹ thuật Đô Thị Mới',
    '(Đô Thị Mới)',
    '02',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '03',
    'Trung Tâm Viễn Thông Bạc Liêu 2',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0310',
    'Tổ Tổng hợp',
    null,
    '03',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '039',
    'Tổ Kỹ thuật Hoà Bình',
    '(Hoà Bình, Minh Diệu)',
    '03',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10112',
    'Tổ Kỹ thuật Cầu Số 2',
    '(Bàu Sàng, Vĩnh Mỹ A, Cầu Số 2)',
    '03',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10114',
    'Tổ Kỹ thuật Cái Cùng',
    '(Cái Cùng, Vĩnh Mới, Vĩnh Hậu)',
    '03',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '04',
    'Trung Tâm Viễn Thông Bạc Liêu 3',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0420',
    'Tổ Tổng hợp',
    null,
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10120',
    'Tổ Kỹ thuật Giá Rai',
    '(Giá Rai, Phong Tân, Phong Thạnh)',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10121',
    'Tổ Kỹ thuật Hộ Phòng',
    '(Hộ Phòng, Cây Gừa)',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10124',
    'Tổ Kỹ thuật Láng Trâm',
    '(Láng Trâm, Khúc Tréo, Ngã Năm, Định Thành, An Phúc)',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10304',
    'Tổ Kỹ thuật Láng Tròn',
    '(Láng Tròn, Xóm Lung, Phong Thạnh Đông)',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10305',
    'Tổ Kỹ thuật Kinh Tư',
    '(Kinh Tư, Cây Giang, Long Điền Đông, Mỹ Điền (Long Điền Đông A))',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10306',
    'Tổ Kỹ thuật Gành Hào',
    '(Gành Hào)',
    '04',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '05',
    'Trung Tâm Viễn Thông Bạc Liêu 4',
    null,
    '01',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '0518',
    'Tổ Tổng hợp',
    null,
    '05',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10137',
    'Tổ Kỹ thuật Phước Long',
    '(Phước Long, Ninh Quới, Rọc Lá, Trưởng Toà)',
    '05',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10143',
    'Tổ Kỹ thuật Ngan Dừa',
    '(Ngan Dừa, Lộc Ninh, Ba Đình, Vĩnh Lộc (Cầu Đỏ), Ninh Hoà, Ninh Điền)',
    '05',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
INSERT INTO Office VALUES(
    '10148',
    'Tổ Kỹ thuật Phó Sinh',
    '(Phó Sinh, Chủ Chí, Ninh Thạnh Lợi, Nhà Lầu 1, Xã Thoàn, Phong Thạnh Tây A)',
    '05',
    '1',
    DEFAULT,
    DEFAULT,
    DEFAULT
);
-- Review's Data ----------------------------------------------------------
INSERT INTO REVIEW VALUES(
    REVIEW_SEQ.NEXTVAL,
    '01',
    '1',
    'TLorem ipsum dolor sit amet, consectetur adipiscing elit. Nam a pellentesque purus. Vivamus vehicula orci tristique sapien sagittis, ac euismod arcu consequat. Vivamus ut cursus erat.',
    DEFAULT,
    DEFAULT
);
INSERT INTO REVIEW VALUES(
    REVIEW_SEQ.NEXTVAL,
    '01',
    '2',
    'TLorem ipsum dolor sit amet, consectetur adipiscing elit. Nam a pellentesque purus. Vivamus vehicula orci tristique sapien sagittis, ac euismod arcu consequat. Vivamus ut cursus erat.',
    DEFAULT,
    DEFAULT
);
INSERT INTO REVIEW VALUES(
    REVIEW_SEQ.NEXTVAL,
    '01',
    '3',
    'TLorem ipsum dolor sit amet, consectetur adipiscing elit. Nam a pellentesque purus. Vivamus vehicula orci tristique sapien sagittis, ac euismod arcu consequat. Vivamus ut cursus erat.',
    DEFAULT,
    DEFAULT
);
INSERT INTO REVIEW VALUES(
    REVIEW_SEQ.NEXTVAL,
    '01',
    '4',
    'TLorem ipsum dolor sit amet, consectetur adipiscing elit. Nam a pellentesque purus. Vivamus vehicula orci tristique sapien sagittis, ac euismod arcu consequat. Vivamus ut cursus erat.',
    DEFAULT,
    DEFAULT
);
INSERT INTO REVIEW VALUES(
    REVIEW_SEQ.NEXTVAL,
    '01',
    '5',
    'TLorem ipsum dolor sit amet, consectetur adipiscing elit. Nam a pellentesque purus. Vivamus vehicula orci tristique sapien sagittis, ac euismod arcu consequat. Vivamus ut cursus erat.',
    DEFAULT,
    DEFAULT
);
