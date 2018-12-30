<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
if(!isset($_GET["id"]))
{
    header("location:ds_san_pham.php");
}
$thongbao="";
require_once("lib/database.php");
$db=new database();
$sql="select * from loai_san_pham";
$db->setQuery($sql);
$ds_loai=$db->loadAllRows();
$sql="select * from san_pham";
$db->setQuery($sql);
$san_pham=$db->loadRow();
if($san_pham==null)
{
    header("location:ds_san_pham.php");
}
if(isset($_POST["btn_xac_nhan"]))
{
    $ten_sp= trim($_POST["ten_san_pham"]);
    $loai_sp= trim($_POST["loai_san_pham"]);
    $gia_ban= trim($_POST["gia_ban"]);
    $so_luong= 0;
    $bao_hanh= trim($_POST["bao_hanh"]);
    $noi_dung= trim($_POST["noi_dung"]);
    $sql="update san_pham set ten_san_pham=?,id_loai=?,gia_ban=?,so_luong=?,bao_hanh=?,noi_dung=? where id_san_pham=?";
    $param=array($ten_sp,$loai_sp,$gia_ban,$so_luong,$bao_hanh,$noi_dung,$_GET["id"]);
    if($_POST["file"]=="co")
    {
        if($_FILES['file_hinh']["type"]!="image/jpeg" && $_FILES['file_hinh']["type"]!="image/jpg" && $_FILES['file_hinh']["type"]!="image/png")
        {
            echo "<script>alert('Hình không đúng định dạng')</script>";
            return;
        }
        else
        {
            $tmp_name = $_FILES["file_hinh"]["tmp_name"];
            $name = $_FILES["file_hinh"]["name"];
            move_uploaded_file($tmp_name, "public/images/sanpham/$name");
            $sql="update san_pham set ten_san_pham=?,id_loai=?,gia_ban=?,so_luong=?,bao_hanh=?,noi_dung=?,hinh=? where id_san_pham=?";
            $param=array($ten_sp,$loai_sp,$gia_ban,$so_luong,$bao_hanh,$noi_dung,$_FILES["file_hinh"]["name"],$_GET["id"]);
        }
    }
    $db->setQuery($sql);
    $db->execute($param);
    $thongbao="Cập nhật thành công";
}
?>
<div class="container-fluid float-left">
    <div class="container mb-5">
        <div class="h2 text-center text-success"><?php echo $thongbao?></div>
        <div class="h1 text-center mb-4">Thêm sản phẩm</div>
        <form action="" method="POST" enctype="multipart/form-data">
            <div class="form-group">
                <label for="ten">Mã sản phẩm</label>
                <input type="text" name="ma_san_pham" class="form-control" required value="<?php echo $_GET["id"]?>" readonly>
            </div>
            <div class="form-group">
                <label for="ten">Tên sản phẩm</label>
                <input type="text" name="ten_san_pham" class="form-control" value="<?php echo $san_pham->ten_san_pham?>" required placeholder="Nhập tên sản phẩm mới">
            </div>
            <div class="form-group">
                <label>Loại sản phẩm</label>
                <select class="form-control" name="loai_san_pham">
                <?php
                    foreach($ds_loai as $ds)
                    {
                ?>
                <option value="<?php echo $ds->ma_loai?>"><?php echo $ds->ten_loai?></option>
                <?php } ?>
                </select>
            </div>
            <div class="form-group">
                <label >Giá bán</label>
                <input type="number" name="gia_ban" value="<?php echo $san_pham->gia_ban?>" class="form-control" required placeholder="Nhập giá bán">
            </div>
            <div class="form-group">
                <label >Số lượng</label>
                <input type="number" name="so_luong" value="<?php echo $san_pham->so_luong?>" class="form-control" required  value="0" readonly>
            </div>
            <div class="form-group">
                <label >Bảo hành</label>
                <input type="text" name="bao_hanh" value="<?php echo $san_pham->bao_hanh?>" class="form-control" required  placeholder="Thời gian tính theo tháng">
            </div>
            <div class="form-check form-check-inline">
                <legend class="mr-2">Cập nhật hình ảnh: </legend>
                <input class="form-check-input" type="radio" name="file" id="file1" value="co">
                <label class="form-check-label" >Có</label>
            </div>
            <div class="form-check form-check-inline">
                <input class="form-check-input" type="radio" name="file" id="file2" value="khong" checked>
                <label class="form-check-label">Không</label>
            </div>
            <div class="form-group">
                <input type="file" name="file_hinh" id="file_hinh" disabled class="form-control-file" required  placeholder="Nhập tên loại mới">
            </div>
            <div class="form-group">
                <label>Nội dung</label>
                <textarea class="form-control" name="noi_dung" rows="5"><?php echo $san_pham->noi_dung?></textarea>
            </div>
            <button type="submit" name="btn_xac_nhan" class="btn btn-primary">Xác nhận</button>
            <button type="reset" class="btn btn-defalt">Làm lại</button>
        </form>
    </div>
</div>
<script>
    file1.onclick=()=>{
        if(file1.checked==true)
            file_hinh.removeAttribute("disabled")
        else
            file_hinh.setAttribute("disabled","")
    }
    file2.onclick=()=>{
        if(file2.checked==true)
        file_hinh.setAttribute("disabled","")
        else
            file_hinh.removeAttribute("disabled")
    }
</script>
<?php
include("layout/footer.php");
?>