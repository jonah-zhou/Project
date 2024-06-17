from django.core.paginator import Paginator, PageNotAnInteger, EmptyPage
from django.shortcuts import render, get_object_or_404

# Create your views here.
from productsApp.models import Product


def products(request, productName):
    submenu = productName
    if productName == 'daqi':
        productName = '大气污染防治设备'
    elif productName == 'lihua':
        productName = '物理化学处理设备'
    else:
        productName = '风机'
    product_list = Product.objects.filter(productType=productName).order_by('-publishDate')

    # 分页处理
    # 每页显示2条数据
    p = Paginator(product_list, 2)
    if p.num_pages <= 1:
        page_data = ''
    else:
        # 得到当前页，默认为1
        page = int(request.GET.get('page', 1))
        # 对页数进行分页
        product_list = p.page(page)
        left = []
        right = []
        left_has_more = False
        right_has_more = False
        first = False
        last = False
        total_pages = p.num_pages   # 总页数
        page_range = p.page_range   # 页数迭代
        if page == 1:
            right = page_range[page:page + 2]
            print(total_pages)
            if right[-1] < total_pages - 1:
                right_has_more = True
            if right[-1] < total_pages:
                last = True
        elif page == total_pages:
            left = page_range[(page - 3) if (page - 3) > 0 else 0:page - 1]
            if left[0] > 2:
                left_has_more = True
            if left[0] > 1:
                first = True
        else:
            left = page_range[(page - 3) if (page - 3) > 0 else 0:page - 1]
            right = page_range[page:page + 2]
            if left[0] > 2:
                left_has_more = True
            if left[0] > 1:
                first = True
            if right[-1] < total_pages - 1:
                right_has_more = True
            if right[-1] < total_pages:
                last = True
        page_data = {
            'left': left,
            'right': right,
            'left_has_more': left_has_more,
            'right_has_more': right_has_more,
            'first': first,
            'last': last,
            'total_pages': total_pages,
            'page': page,
        }

    context = {
        'active_menu': 'products',
        'sub_menu': submenu,
        'productName': productName,
        'productList': product_list,
        'pageData': page_data
    }
    return render(request, 'productsApp/productList.html', context)


def product_detail(request, id):
    """产品的详情页"""
    product = get_object_or_404(Product, id=id)  # 按id进行查找，没有时返回404
    product.views += 1  # 浏览数加1
    product.save()
    return render(request, 'productsApp/productDetail.html', {
        'active_menu': 'products',
        'product': product,
    })

