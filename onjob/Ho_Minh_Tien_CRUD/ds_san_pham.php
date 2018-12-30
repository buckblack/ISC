<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
$thongbao="";
require_once("lib/database.php");
$db=new database();
$sql="select * from san_pham s, loai_san_pham l where s.id_loai=l.ma_loai";
$db->setQuery($sql);
$danh_sach=$db->loadAllRows();

?>
<div class="container-fluid float-left">
    <div class="container">
        <div class="h1 text-center mb-4">Danh sách loại sản phẩm</div>
        <table class="table table-striped table-table-hover table-responsive border d-md-table">
            <thead class="bg-primary text-light">
                <tr>
                    <th>Mã</th>
                    <th>Hình</th>
                    <th class="text-nowrap">Tên sản phẩm</th>
                    <th class="text-nowrap">Loại sản phẩm</th>
                    <th class="text-nowrap">Giá bán</th>
                    <th class="text-nowrap">Số lượng</th>
                    <th class="text-nowrap">Bảo hành</th>
                    <th class="text-nowrap">Nội dung</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <?php
                    foreach($danh_sach as $ds)
                    { 
                ?>
                    <tr>
                        <td><?php echo $ds->id_san_pham?></td>
                        <td><img style="width:50px" src="public/images/sanpham/<?php echo $ds->hinh?>" alt=""></td>
                        <td><?php echo $ds->ten_san_pham?></td>
                        <td><?php echo $ds->ten_loai?></td>
                        <td><?php echo $ds->gia_ban?></td>
                        <td><?php echo $ds->so_luong?></td>
                        <td><?php echo $ds->bao_hanh?></td>
                        <td><?php echo substr($ds->noi_dung,0,30) . "..."?></td>
                        <td class="text-nowrap">
                            <a href="sua_san_pham.php?id=<?php echo $ds->id_san_pham?>"><i class="fa fa-pencil-square-o"></i></a>
                            <a href="#"><i class="fa fa-remove" onclick="xoa(<?php echo $ds->id_san_pham?>)"></i></a>
                        </td>
                    </tr>
                    <?php }?>
                </tbody>
        </table>
    </div>
</div>
<script>
    function xoa(id) {
        var r = confirm("Xác nhận xóa");
        if (r == true)
        {
            window.location="xoa_san_pham.php?id="+id
        }
    }
</script>
<?php
include("layout/footer.php");
?>