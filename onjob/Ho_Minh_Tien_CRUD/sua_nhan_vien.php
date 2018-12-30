<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
if(!isset($_GET["id"]))
{
    header("location:ds_nhan_vien.php");
}
$thongbao="";
require_once("lib/database.php");
$db=new database();
$sql="select * from nhan_vien where id_nhan_vien=".$_GET['id'];
$db->setQuery($sql);
$nhan_vien=$db->loadRow();
if($nhan_vien==null)
{
    header("location:ds_nhan_vien.php");
}
if(isset($_POST["btn_xac_nhan"]))
{
    $ho_ten= trim($_POST["ho_ten"]);
    $dia_chi= trim($_POST["dia_chi"]);
    $nam_sinh= trim($_POST["nam_sinh"]);
    $gioi_tinh= $_POST["sex"];
    $quyen= $_POST["role"];
    $dien_thoai= trim($_POST["dien_thoai"]);
    $sql="update nhan_vien set ho_ten=?,dia_chi=?,nam_sinh=?,gioi_tinh=?,quyen=?,dien_thoai=? where id_nhan_vien=?";
    $db->setQuery($sql);
    $param=array($ho_ten,$dia_chi,$nam_sinh,$gioi_tinh,$quyen,$dien_thoai,$_GET["id"]);
    $db->execute($param);
    $thongbao="Cập nhật thành công";
    
}
?>
<div class="container-fluid float-left">
    <div class="container mb-5">
        <div class="h2 text-center text-success"><?php echo $thongbao?></div>
        <div class="h1 text-center mb-4">Thêm nhân viên</div>
        <form action="" method="POST" enctype="multipart/form-data">
            <div class="form-group">
                <label >Mã nhân viên</label>
                <input type="text" name="id_nhan_vien" readonly value="<?php echo $nhan_vien->id_nhan_vien?>" class="form-control" required >
            </div>
            <div class="form-group">
                <label for="ten">Họ tên</label>
                <input type="text" name="ho_ten" class="form-control" value="<?php echo $nhan_vien->ho_ten?>" required placeholder="Nhập họ tên">
            </div>
            <div class="form-group">
                <label >Địa chỉ</label>
                <input type="text" name="dia_chi" class="form-control" value="<?php echo $nhan_vien->dia_chi?>" required placeholder="Địa chỉ">
            </div>
            <div class="form-group">
                <label >Năm sinh</label>
                <input type="number" name="nam_sinh" class="form-control" value="<?php echo $nhan_vien->nam_sinh?>" required  placeholder="Nhập năm sinh">
            </div>
            
            <div class="form-group">
                <label >Giới tính:</label>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="sex" value="1" <?php if($nhan_vien->gioi_tinh==1) echo "checked"?>>
                    <label class="form-check-label" >Nam</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="sex" value="0" <?php if($nhan_vien->gioi_tinh==0) echo "checked"?>>
                    <label class="form-check-label" >Nữ</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="sex" value="2" <?php if($nhan_vien->gioi_tinh==2) echo "checked"?>>
                    <label class="form-check-label" >Khác</label>
                </div>
            </div>
            <div class="form-group">
                <label >Điện thoại</label>
                <input type="tel" name="dien_thoai" class="form-control" required value="<?php echo $nhan_vien->dien_thoai?>"  placeholder="Nhập số điện thoại">
            </div>
            <div class="form-group">
                <label >Quyền:</label>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="role" value="1" <?php if($nhan_vien->quyen==1) echo "checked"?>>
                    <label class="form-check-label" >Quản lý</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="role" value="0" <?php if($nhan_vien->quyen==0) echo "checked"?>>
                    <label class="form-check-label" >Nhân viên</label>
                </div>
            </div>
            <div class="form-group">
                <label >Email</label>
                <input type="email" name="email" class="form-control" disabled value="<?php echo $nhan_vien->email?>" required  placeholder="Nhập email">
            </div>
            <button type="submit" name="btn_xac_nhan" class="btn btn-primary">Xác nhận</button>
            <button type="reset" class="btn btn-defalt">Làm lại</button>
        </form>
    </div>
</div>
<?php
include("layout/footer.php");
?>