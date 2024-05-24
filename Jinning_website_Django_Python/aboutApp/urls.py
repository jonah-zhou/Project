from django.urls import path
from aboutApp import views

app_name = 'aboutApp'

urlpatterns = [
    path('survey/', views.survey, name='survey'),
    path('honor/', views.honor, name='honor'),
]