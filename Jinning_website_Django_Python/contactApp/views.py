from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.
def contact(request):
    html = "<html><body>Contact Page</body></html>"
    return HttpResponse(html)

def recruit(request):
    html = "<html><body>Recruitment Page</body></html>"
    return HttpResponse(html)