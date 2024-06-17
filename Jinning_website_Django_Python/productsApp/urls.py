
from django.urls import path
from productsApp import views

app_name = 'productsApp'

urlpatterns = [
    path('products/<str:productName>/', views.products, name='products'),
    path('products_details/<int:id>/', views.product_detail, name="products_details"),
]