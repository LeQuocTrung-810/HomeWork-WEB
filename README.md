<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/e67587de-1ca3-44eb-9ddd-ecd44eb97673" /># HomeWork-WEB
## TẠO SOLUTION GỒM CÁC PROJECT SAU:
DLL đa năng, keyword: c# window library -> Class Library (.NET Framework) bắt buộc sử dụng .NET Framework 2.0: giải bài toán bất kỳ, độc lạ càng tốt, phải có dấu ấn cá nhân trong kết quả, biên dịch ra DLL. DLL độc lập vì nó ko nhập, ko xuất, nó nhận input truyền vào thuộc tính của nó, và trả về dữ liệu thông qua thuộc tính khác, hoặc thông qua giá trị trả về của hàm. Nó độc lập thì sẽ sử dụng được trên app dạng console (giao diện dòng lệnh - đen sì), cũng sử dụng được trên app desktop (dạng cửa sổ), và cũng sử dụng được trên web form (web chạy qua iis).  
Console app, bắt buộc sử dụng .NET Framework 2.0, sử dụng được DLL trên: nhập được input, gọi DLL, hiển thị kết quả, phải có dấu án cá nhân. keyword: c# window Console => Console App (.NET Framework), biên dịch ra EXE  
Windows Form Application, bắt buộc sử dụng .NET Framework 2.0**, sử dụng được DLL đa năng trên, kéo các control vào để có thể lấy đc input, gọi DLL truyền input để lấy đc kq, hiển thị kq ra window form, phải có dấu án cá nhân; keyword: c# window Desktop => Windows Form Application (.NET Framework), biên dịch ra EXE  
Web đơn giản, bắt buộc sử dụng .NET Framework 2.0, sử dụng web server là IIS, dùng file hosts để tự tạo domain, gắn domain này vào iis, file index.html có sử dụng html css js để xây dựng giao diện nhập được các input cho bài toán, dùng mã js để tiền xử lý dữ liệu, js để gửi lên backend. backend là api.aspx, trong code của api.aspx.cs thì lấy được các input mà js gửi lên, rồi sử dụng được DLL đa năng trên. kết quả gửi lại json cho client, js phía client sẽ nhận được json này hậu xử lý để thay đổi giao diện theo dữ liệu nhận dược, phải có dấu án cá nhân. keyword: c# window web => ASP.NET Web Application (.NET Framework) + tham khảo link chatgpt thầy gửi. project web này biên dịch ra DLL, phải kết hợp với IIS mới chạy được.  
## 1. Tạo solution và Project DLL ( ClassLibrary .NET FrameWork 2.0)
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/599b0446-7706-443d-ad3e-714560cd2eec" />

## 2. Tạo Project Console App (.Net FrameWork 2.0)
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/a83ddec3-d251-49dc-8b48-71ada7eed067" />

## 3. Tạo Windows Form Application (.NET FrameWork 2.0)
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/dc2e17ba-24c1-4641-a06d-5e17dbf12d4e" />

## 4. Tạo Project Web (.NET FrameWork 2.0)
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/a46b62cc-14f8-44e6-94b0-6b1ae22ca6e2" />

## Chạy web vào thử bài toán => kết quả  
<img width="1919" height="1050" alt="image" src="https://github.com/user-attachments/assets/f46f189f-34b7-4e19-8ba0-58e60d03fa50" />
