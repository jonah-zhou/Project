import os
import smtplib
import ssl
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from django.core.mail import send_mail
from django.db.models.signals import post_init, post_save
from django.dispatch import receiver
from docx.shared import Mm
from docxtpl import DocxTemplate, InlineImage
from contactApp.models import Resume
from docx2pdf import convert

# Custom email sending function using smtplib
def send_custom_mail(subject, body, from_email, to_email):
    # Set up the email content
    message = MIMEMultipart()
    message["Subject"] = subject
    message["From"] = from_email
    message["To"] = to_email
    message.attach(MIMEText(body, "plain"))

    # Create SSL context
    context = ssl.create_default_context()

    try:
        # Connect to SMTP server
        with smtplib.SMTP("smtp.gmail.com", 587) as server:
            server.ehlo()  # Optional
            server.starttls(context=context)  # Start TLS encryption
            server.ehlo()  # Optional

            # Login to SMTP server
            server.login(from_email, "abwuglmxxdtxtotu")

            # Send email
            server.sendmail(from_email, to_email, message.as_string())
            print("Email sent successfully!")
    except Exception as e:
        print(f"Error occurred: {e}")

# Trigger functions
@receiver(post_init, sender=Resume)
def before_save_resume(sender, instance, **kwargs):
    """Trigger: post_init is called when an instance is initialized."""
    instance.__original_status = instance.status  # Record the original status

@receiver(post_save, sender=Resume)
def post_save_resume(sender, instance, **kwargs):
    """Trigger: post_save is called after an instance is saved."""
    email = instance.email  # Get applicant's email
    EMAIL_FROM = 'jonah.zhou.js@gmail.com'  # Sender's email

    # Check if the previous status is different from the current status
    if hasattr(instance, '__original_status'):
        if instance.__original_status == 1 and instance.status == 2:
            email_title = 'Interview Result from Jinning Engineering Plastics Co., Ltd.'
            email_body = 'Congratulations on passing the initial interview! Please visit our company for the second interview this week!'
            send_custom_mail(email_title, email_body, EMAIL_FROM, email)
            generate_documents(instance)
        elif instance.__original_status == 1 and instance.status == 3:
            email_title = 'Interview Result from Jinning Engineering Plastics Co., Ltd.'
            email_body = 'We regret to inform you that you did not pass the initial interview. Thank you for your interest.'
            send_custom_mail(email_title, email_body, EMAIL_FROM, email)

def generate_documents(instance):
    # Generate dynamic word document
    template_path = os.path.join(os.getcwd(), "media", "contact", "recruit.docx")

    # Load template
    template = DocxTemplate(template_path)

    # Context data for template rendering
    context = {
        'name': instance.name,
        'personID': instance.personID,
        'sex': instance.sex,
        'email': instance.email,
        'birth': instance.birth,
        'edu': instance.edu,
        'school': instance.school,
        'major': instance.major,
        'position': instance.position,
        'experience': instance.experience,
        # Ensure the following line works correctly without errors
        # 'photo': InlineImage(template, instance.photo, width=Mm(30), height=Mm(40)),
    }

    # Render the template
    template.render(context)

    # File paths
    docx_filename = os.path.join(os.getcwd(), "media", "contact", "recruit", f"{instance.name}_{instance.id}.docx")
    pdf_filename = os.path.join(os.getcwd(), "media", "contact", "recruit", f"{instance.name}_{instance.id}.pdf")

    # Save the rendered template as DOCX
    template.save(docx_filename)

    # Convert DOCX to PDF
    if os.path.exists(docx_filename):
        convert(docx_filename, pdf_filename)
        print("PDF conversion successful")
    else:
        print("DOCX file does not exist")
