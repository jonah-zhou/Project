
from django.urls import path
from productsApp import views

app_name = 'productsApp'

urlpatterns = [
    path('daqi/', views.daqi, name='daqi'),
    path('lihua/', views.lihua, name='lihua'),
    path('fengji/', views.fengji, name='fengji'),
]