<?php
include("layout/head.php");
include("layout/nav.php");
include("layout/quick.php");
?>
<?php
$thongbao="";
require_once("lib/database.php");
$db=new database();
$sql="SELECT id_nhan_vien,ho_ten,dia_chi,nam_sinh,dien_thoai,email,if(quyen=1,'Quản lý','Nhân viên') as 'quyen',if(gioi_tinh=1,'Nam',if(gioi_tinh=0,'Nữ','Khác')) as 'gioi_tinh' FROM nhan_vien";
$db->setQuery($sql);
$danh_sach=$db->loadAllRows();
?>
<div class="container-fluid float-left">
    <div class="container">
        <div class="h1 text-center mb-4">Danh sách nhân viên</div>
        <table class="table table-striped table-table-hover table-responsive border d-md-table">
            <thead class="bg-primary text-light">
                <tr>
                    <th>Mã</th>
                    <th class="text-nowrap">Tên</th>
                    <th class="text-nowrap">Địa chỉ</th>
                    <th class="text-nowrap">Năm sinh</th>
                    <th class="text-nowrap">Giới tính</th>
                    <th class="text-nowrap">Quyền</th>
                    <th class="text-nowrap">Điện thoại</th>
                    <th class="text-nowrap">Email</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                <?php
                    foreach($danh_sach as $ds)
                    { 
                ?>
                    <tr>
                        <td><?php echo $ds->id_nhan_vien?></td>
                        <td><?php echo $ds->ho_ten?></td>
                        <td><?php echo $ds->dia_chi?></td>
                        <td><?php echo $ds->nam_sinh?></td>
                        <td><?php echo $ds->gioi_tinh?></td>
                        <td><?php echo $ds->quyen?></td>
                        <td><?php echo $ds->dien_thoai?></td>
                        <td><?php echo $ds->email?></td>
                        <td class="text-nowrap">
                            <a href="sua_nhan_vien.php?id=<?php echo $ds->id_nhan_vien?>"><i class="fa fa-pencil-square-o"></i></a>
                            <a href="#"><i class="fa fa-remove" onclick="xoa_nhan_vien(<?php echo $ds->id_nhan_vien?>)"></i></a>
                        </td>
                    </tr>
                    <?php }?>
                </tbody>
        </table>
    </div>
</div>
<script>
    function xoa_nhan_vien(id) {
        var r = confirm("Xác nhận xóa");
        if (r == true)
        {
            window.location="xoa_nhan_vien.php?id="+id
        }
    }
</script>
<?php
include("layout/footer.php");
?>