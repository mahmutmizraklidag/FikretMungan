using FikretMungan.Entities;

namespace FikretMungan.Tools
{
    public class MailTemplates
    {
        public static string ContactFormTemplate(ContactForm contact)
        {
            string mailTemplate = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Yeni İletişim Mesajı</title>
    <style>
        body {{ margin: 0; padding: 0; background-color: #f4f7ff; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; }}
        .container {{ width: 100%; max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 20px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.05); }}
        .header {{ background-color: #d8947c; padding: 40px 20px; text-align: center; }}
        .header h1 {{ color: #ffffff; margin: 0; font-size: 24px; font-weight: 600; letter-spacing: 1px; }}
        .content {{ padding: 40px 30px; color: #6b6b6b; }}
        .greeting {{ font-size: 18px; color: #242424; margin-bottom: 20px; font-weight: 600; }}
        .info-box {{ background-color: #f9f9f9; border: 1px solid #eee; border-radius: 15px; padding: 20px; margin: 20px 0; }}
        .info-row {{ display: flex; justify-content: space-between; margin-bottom: 12px; border-bottom: 1px dotted #eee; padding-bottom: 12px; }}
        .info-row:last-child {{ border-bottom: none; margin-bottom: 0; padding-bottom: 0; }}
        .label {{ font-weight: 600; color: #d8947c; min-width: 100px; }}
        .value {{ color: #242424; text-align: right; font-weight: 500; }}
        .message-area {{ background-color: #fff; border-left: 4px solid #d8947c; padding: 15px; margin-top: 20px; border-radius: 0 10px 10px 0; box-shadow: 0 2px 5px rgba(0,0,0,0.03); }}
        .message-title {{ font-size: 14px; font-weight: bold; color: #242424; margin-bottom: 10px; display: block; }}
        .message-text {{ font-size: 15px; line-height: 1.6; color: #555; font-style: italic; }}
        .footer {{ background-color: #242424; color: #ffffff; text-align: center; padding: 20px; font-size: 12px; }}
        .btn {{ display: inline-block; background-color: #d8947c; color: #ffffff; padding: 10px 20px; text-decoration: none; border-radius: 25px; margin-top: 20px; font-size: 14px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Yeni Mesaj Var! 📩</h1>
        </div>
        <div class='content'>
            <p class='greeting'>Merhaba Yönetici,</p>
            <p>Web sitesindeki iletişim formundan yeni bir talep oluşturuldu. Detaylar aşağıdadır:</p>
            
            <div class='info-box'>
                <div class='info-row'>
                    <span class='label'>Ad Soyad:</span>
                    <span class='value'>{contact.Name}</span>
                </div>
                <div class='info-row'>
                    <span class='label'>E-posta:</span>
                    <span class='value'><a href='mailto:{contact.Email}' style='color:#242424; text-decoration:none;'>{contact.Email}</a></span>
                </div>
                <div class='info-row'>
                    <span class='label'>Telefon:</span>
                    <span class='value'>{contact.Phone ?? "-"}</span>
                </div>
                <div class='info-row'>
                    <span class='label'>Tarih:</span>
                    <span class='value'>{DateTime.Now.ToString("dd.MM.yyyy HH:mm")}</span>
                </div>
                <div class='info-row'>
                    <span class='label'>Konu:</span>
                    <span class='value'>{contact.Subject}</span>
                </div>
            </div>

            <div class='message-area'>
                <span class='message-title'>📝 Mesaj İçeriği:</span>
                <div class='message-text'>
                    ""{contact.Message}""
                </div>
            </div>
            
            <div style='text-align:center;'>
                <a href='mailto:{contact.Email}' class='btn'>Yanıtla</a>
            </div>
        </div>
        <div class='footer'>
            <p>© {DateTime.Now.Year} Uzm. Dr. Fikret MUNGAN Yönetim Paneli</p>
        </div>
    </div>
</body>
</html>";
            return mailTemplate;
        }
        public static string CustomerConfirmationTemplate(ContactForm contact)
        {
            string mailTemplate = $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Mesajınız Alındı</title>
    <style>
        body {{ margin: 0; padding: 0; background-color: #f4f7ff; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; }}
        .container {{ width: 100%; max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 20px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.05); }}
        .header {{ background-color: #d8947c; padding: 40px 20px; text-align: center; }}
        .header h1 {{ color: #ffffff; margin: 0; font-size: 24px; font-weight: 600; letter-spacing: 1px; }}
        .content {{ padding: 40px 30px; color: #6b6b6b; text-align: center; }}
        .greeting {{ font-size: 20px; color: #242424; margin-bottom: 20px; font-weight: 600; }}
        .success-icon {{ font-size: 50px; margin-bottom: 20px; }}
        .message-box {{ background-color: #f9f9f9; border-radius: 15px; padding: 25px; margin: 25px 0; text-align: left; border: 1px solid #eee; }}
        .message-box p {{ margin: 0; line-height: 1.6; color: #555; }}
        .footer {{ background-color: #242424; color: #ffffff; text-align: center; padding: 25px; font-size: 13px; }}
        .footer a {{ color: #d8947c; text-decoration: none; }}
        .social-text {{ color: #888; margin-top: 10px; font-size: 12px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>Mesajınız Bize Ulaştı!</h1>
        </div>
        <div class='content'>
            <div class='success-icon'>✅</div>
            <p class='greeting'>Sayın {contact.Name},</p>
            <p>Web sitemiz üzerinden iletmiş olduğunuz mesajınız başarıyla tarafımıza ulaşmıştır. İlginiz için teşekkür ederiz.</p>
            
            <div class='message-box'>
                <p><strong>İlettiğiniz Konu:</strong> {contact.Subject}</p>
                <p style='margin-top:10px;'>En kısa sürede inceleyip belirttiğiniz e-posta adresi veya telefon numarası üzerinden sizinle iletişime geçeceğiz.</p>
            </div>

            <p style='font-size: 15px;'>Sağlıklı günler dileriz.</p>
        </div>
        <div class='footer'>
            <p><strong>Uzm. Dr. Fikret MUNGAN</strong></p>
            <p style='margin: 5px 0;'>Çocuk Sağ. Ve Hastalıkları Hekimi</p>
            <p class='social-text'>Bu e-posta bir bilgilendirme mesajıdır, lütfen yanıtlamayınız.</p>
            <p style='margin-top:15px; font-size: 11px; border-top: 1px solid #444; padding-top: 15px;'>
                © {DateTime.Now.Year} | <a href='https://fikretmungan.com'>fikretmungan.com</a>
            </p>
        </div>
    </div>
</body>
</html>";
            return mailTemplate;
        }
    }
}
