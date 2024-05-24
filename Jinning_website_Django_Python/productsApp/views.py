from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.

def daqi(request):
    html = "<html><body>daqi Page</body></html>"
    return HttpResponse(html)

def lihua(request):
    html = "<html><body>lihua Page</body></html>"
    return HttpResponse(html)

def fengji(request):
    html = "<html><body>fengji Page</body></html>"
    return HttpResponse(html)