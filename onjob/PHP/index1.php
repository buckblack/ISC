<!doctype html>
<html lang="en">

<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="public/css/bootstrap.min.css">
    <link rel="stylesheet" href="public/css/style.css">
    <title>Admin</title>
</head>

<body>
    <div class="container-fluid">
        <div class="row">
        <div class="col-lg-2 pt-5">
            <div class="panel-group" id="pn_group">
            <div class="panel panel-primary">
                    <div class="panel-heading">
                        <a href="#pn_3" data-toggle="collapse" data-parent="#pn_group"><p class="h1 panel-title btn btn-outline-primary w-100">Loại sản phẩm</p></a>
                    </div>
                    <div class="panel-collapse collapse" id="pn_3">
                        <div class="panel-body">
                        <a href="them_loai.php" class="btn btn-outline-dark w-75 float-right mb-2">Thêm mới</a>
                        <a href="ds_loai.php" class="btn btn-outline-dark w-75 float-right mb-2">Danh sách</a>
                        </div>
                    </div>
                </div>
                <div class="panel panel-primary">
                    
                    <div class="panel-heading">
                        <a href="#pn_1" data-toggle="collapse" data-parent="#pn_group"><p class="h1 panel-title btn btn-outline-primary w-100">Sản phẩm</p></a>
                    </div>
                    <div class="panel-collapse collapse" id="pn_1">
                        <div class="panel-body">
                        <a href="#" class="btn btn-outline-dark w-75 float-right mb-2">Thêm mới</a>
                        <a href="#" class="btn btn-outline-dark w-75 float-right mb-2">Danh sách</a>
                        </div>
                    </div>
                </div>
                
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <a href="#pn_2" data-toggle="collapse" data-parent="#pn_group"><p class="h1 panel-title btn btn-outline-primary w-100">Nhân viên</p></a>
                    </div>
                    <div class="panel-collapse collapse" id="pn_2">
                        <div class="panel-body">
                        <a href="#" class="btn btn-outline-dark w-75 float-right mb-2">Thêm mới</a>
                        <a href="#" class="btn btn-outline-dark w-75 float-right mb-2">Danh sách</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col-lg-10">
            <a href="#"><div class="quick text-center">
                <img src="public/images/add.png" class="img-fluid" alt="">
                <p class="text-center">Thêm sản phẩm</p>
            </div></a>
            <a href="#"><div class="quick text-center">
                <img src="public/images/employee.png" class="img-fluid" alt="">
                <p class="text-center">Thêm khách hàng</p>
            </div></a>
            <div class="clear"></div>
            <div class="container-fluid">
                <div class="container">
                    <button class="btn btn-outline-dark w-100"></button>
                </div>
            </div>
        </div>
        </div>
</div>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="public/js/jquery-3.3.1.min.js"></script>
    <script src="public/js/bootstrap.bundle.min.js"></script>
</body>

</html>