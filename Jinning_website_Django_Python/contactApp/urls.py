from django.urls import path
from contactApp import views

app_name = 'contactApp'

urlpatterns = [
    path('contact/', views.contact, name='contact'),
    path('recruit/', views.recruit, name='recruit'),
]
