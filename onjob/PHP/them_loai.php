<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
$thongbao="";
require_once("lib/database.php");
$db=new database();
if(isset($_POST["btn_xac_nhan"]))
{
    $ten= $_POST["ten_loai"];
    if(trim($ten)=="")
    {
        $thongbao="Chưa nhập tên";
    }
    else
    {
        $sql="insert into loai_san_pham(ten_loai) values(?)";
        $db->setQuery($sql);
        $param=array(trim($ten));
        $db->execute($param);
        $thongbao="Thêm thành công";
    }
}
?>
<div class="container-fluid float-left">
    <div class="container">
        <div class="h2 text-center text-success"><?php echo $thongbao?></div>
        <div class="h1 text-center mb-4">Thêm loại sản phẩm</div>
        <form action="" method="POST">
            <div class="form-group">
                <label for="ten">Tên loại sản phẩm</label>
                <input type="text" name="ten_loai" class="form-control" required id="ten_loai" placeholder="Nhập tên loại mới">
            </div>
            <button type="submit" name="btn_xac_nhan" class="btn btn-primary">Xác nhận</button>
            <button type="reset" class="btn btn-defalt">Làm lại</button>
        </form>
    </div>
</div>
<?php
include("layout/footer.php");
?>