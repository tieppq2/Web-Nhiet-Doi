/**
 * @Project HOSPITAL
 * @Author NGOI SAO SO Co., Ltd.
 * @Copyright (C) 2015 NGOI SAO SO Co., Ltd. All rights reserved
 * @Createdate Sat, 26 Dec 2015 13:41:02 GMT
 */

function appointment_book(id)
{
	$('#idmodals').removeData('bs.modal');
	var url = nv_base_siteurl + 'index.php?' + nv_lang_variable + '=' + nv_lang_data + '&' + nv_name_variable + '=' + nv_module_name + '&' + nv_fc_variable + '=appointment_modal' + '&id=' + id;
	$.post(url + '&id=' + id, function(res)
	{
		$('#idmodals .modal-body').html(res);
		$('#idmodals').modal('show');
	});
}

function appointment_book_block(id, module_block)
{
	$('#idmodals').removeData('bs.modal');
	var url = nv_base_siteurl + 'index.php?' + nv_lang_variable + '=' + nv_lang_data + '&' + nv_name_variable + '=' + module_block + '&' + nv_fc_variable + '=appointment_modal' + '&id=' + id;
	$.post(url, function(res)
	{
		$('#idmodals .modal-body').html(res);
		$('#idmodals').modal('show');
	});
}