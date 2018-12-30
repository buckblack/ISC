<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
$thongbao="";
require_once("lib/database.php");
$db=new database();
$sql="select * from loai_san_pham";
$db->setQuery($sql);
$danh_sach=$db->loadAllRows();
?>
<div class="container-fluid float-left">
    <div class="container">
        <div class="h1 text-center mb-4">Danh sách loại sản phẩm</div>
        <table class="table table-striped table-table-hover table-responsive d-table border">
            <thead class="bg-primary text-light">
                <tr>
                    <th>Mã loại</th>
                    <th>Tên loại</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <?php
                    foreach($danh_sach as $ds)
                    { 
                ?>
                    <tr>
                        <td><?php echo $ds->ma_loai?></td>
                        <td><?php echo $ds->ten_loai?></td>
                        <td><a href="sua_loai.php?id=<?php echo $ds->ma_loai?>"><i class="fa fa-pencil-square-o"></i></a></td>
                    </tr>
                    <?php }?>
                </tbody>
        </table>
    </div>
</div>
<?php
include("layout/footer.php");
?>