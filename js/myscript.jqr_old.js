(function($) {
	$(document).ready(function() {
	        $(window).load(function () {
	            if($("#luu").attr("add") == "False")
		            $("#luu").attr("disabled",true).css("background","#cfcfcf");
		            
                if($("#_luu").attr("edit") == "False")
		            $("#_luu").attr("disabled",true).css("background","#cfcfcf");
		            
		        if($("#xoa").attr("delete") == "False")
		            $("#xoa").attr("disabled",true).css("background","#cfcfcf");
		            
		        if($("#timKiem").attr("search") == "False")
		            $("#timKiem").attr("disabled",true).css("background","#cfcfcf");
		            
	        });
            
		var w = screen.availWidth;
		var h = screen.availHeight;
		window.moveTo(0, 0);
		window.resizeTo(w, h);
		$('form:not(.filter) :input:visible:first').focus();
	});
	$.BindFind = function(options, before, after) {
		options = $.extend({ }, $.defaults, options);
		if (options.ajax == "")
			alert("Path ajax is null.");
		$.mkv.BindDuLieuTimKiem(options, before, after);
	};
	$.fn.extend({
			TimKiem: function(options, before, after) {
				options = $.extend({ }, $.defaults, options);
				if (options.ajax == "")
					alert("Path ajax is null.");
				$.mkv.LoadTimKiem($(this), options, before, after);
			},
			Luu: function(options, before, after,afterUpdate) {
			     
				$(this).attr("id").indexOf('_') != -1 ? $.defaults.ctlLuu = $(this).attr("id").replace("_", "") : $.defaults.ctlLuu = $(this).attr("id");

				options = $.extend({ }, $.defaults, options);

				if (options.ajax == "") {
					if (options.ajaxLuu == "")
						alert("Path ajaxLuu is null.");
					if (options.ajaxSua == "")
						alert("Path ajaxSua is null.");
				}
				$.mkv.Save.run($(this), options, before, after,afterUpdate);
			},
			Moi: function(options) {
				$.defaults.ctlMoi = $(this).attr("id");
				options = $.extend({ }, $.defaults, options);
				$.mkv.New(options);
				$.mkv.XoaTrangData(options);
				$.mkv.ExtendtionLuu(false, options);
			},
			DropList: function(options, before, after) {
				options = $.extend({ }, $.defaults, options);
				$.mkv.binddroplist(this, options, before, after);
			},
			Xoa: function(options, before, after) {
				options = $.extend({ }, $.defaults, options);
				if (options.ajax == "")
					alert("Path ajax is null.");
				if($.isNullOrEmpty(before))
					if (!confirm(options.valueConfirm))
						return false;
				$.mkv.Xoakhoachinh(this, options, before, after);
			},
			LuuTable: function(options, before, after) {
				options = $.extend({ }, $.defaults, options);
				if ($("#" + options.tablename).attr("id") == null)
					alert("'tablename:" + options.tablename + "' LuuTable not found.");
				if (options.ajax == "")
					alert("Path ajax is null.");
				if (!$.isNullOrEmpty(before))
					if (!before())
						return false;
				$.mkv.jTable.savewithSubmit($(this), options, after);
			},
			XoaRow: function(options, before, after) {
				options = $.extend({ }, $.defaults, options);
				if ($("#" + options.idkhoachinh).attr("id") == null)
					alert("idkhoachinh not found.");
				if (options.ajax == "")
					alert("Path ajax is null.");
				if (before == null) {
					before = function() {
						if (!confirm(options.valueConfirm))
							return false;
						else
							return true;
					};
				}
				$.mkv.jTable.xoa($(this), options, before, after);
			},
			validDate:function () {
				$(this).keydown(function (event) {
					if(event.keyCode == 9 || event.keyCode == 8 || event.keyCode == 46 || event.keyCode == 37 || event.keyCode == 39)return;
					if((event.keyCode >= 96 && event.keyCode <= 105) || (event.keyCode >= 48 && event.keyCode <= 57)){
						if((this.value.substring(0,$(this).val().indexOf("/")).length == 2 && ($.getCharacter(this) < 3 && this.value.split("/").length >= 3)) || $.getCharacter(this) == 2){
								return false;
						}else if($(this).val().substring($(this).val().indexOf("/"),$(this).val().lastIndexOf("/")).length == 3 && ($.getCharacter(this) < 6 && $.getCharacter(this) > 2)){
								return false;
						}else if($(this).val().substring($(this).val().lastIndexOf("/"),$(this).val().length).length >= 5 && $.getCharacter(this) > 5){
								return false;
						}
						if(this.value.substring(0,$.getCharacter(this)).length == 2){
							if(this.value.substring($.getCharacter(this),3) != "/"){
								$.textAtCursor(this,"/");
								return false;                 
							}
						}else if(this.value.substring(this.value.indexOf("/"),$.getCharacter(this)).length == 3){
							if(this.value.substring($.getCharacter(this),6) != "/"){
								$.textAtCursor(this,"/");  
								return false;
							}
						}
					}else{
						return false;
					}
				}).keyup(function (event) {
					if(event.keyCode == 9 || event.keyCode == 8 || event.keyCode == 46 || event.keyCode == 37 || event.keyCode == 39)return;
					if(this.value.substring(0,$.getCharacter(this)).length == 2){
						if(this.value.substring($.getCharacter(this),3) != "/"){
							$.textAtCursor(this,"/");                 
						}
					}else if(this.value.substring(this.value.indexOf("/"),$.getCharacter(this)).length == 3){
						if(this.value.substring($.getCharacter(this),6) != "/")
							$.textAtCursor(this,"/");  
					}
				}).blur(function () {
					$(this).unbind("keydown");
					$(this).unbind("blur");
					$.TestDate(this);
				});
				
			} 
		});
	$.LuuTable = function(options, before, after) {
		options = $.extend({ }, $.defaults, options);
		if ($("#" + options.tablename).attr("id") == null)
			alert("'tablename:" + options.tablename + "' LuuTable not found.");
		if (options.ajax == "")
			alert("Path ajax is null.");
		if (!$.isNullOrEmpty(before))
			if (!before())
				return false;
		$.mkv.jTable.save(null, options, after);
	};
	$.fn.extend({
			readControl: function() {
				var list = "";
				eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('7($(0).1("h")||$(0).1("g")||$(0).1("e")){c($(0).2("j")){9"f":3+="&"+$(0).2("4")+"="+$(0).1(\':a\');8;9"l":7($(0).1(\':a\'))3+="&"+$(0).2("4")+"="+5($(0).6());8;i:3+="&"+$(0).2("4")+"="+5($(0).6());8}}b 7($(0).1("k")){3+="&"+$(0).2("4")+"="+5($(0).6())}b{3+="&"+$(0).2("4")+"="+5($(0).d())}',22,22,'this|is|attr|list|id|encodeURIComponent|val|if|break|case|checked|else|switch|text|textarea|checkbox|select|input|default|type|span|radio'.split('|'),0,{}))
				return list;
			}
		});
	$.defaults = {
		width: "700px",
		height: "300px",
		showPopup:true,
		ajax: "",
		idkhoachinh: "idkhoachinh",
		title: "Danh sách dữ liệu",
		Frame: ".body-div .in-a",
		tablename: "",
		valueBtLuu: "Lưu/Dừng",
		ctlLuu: 'luu',
		ctlXoa: 'xoa',
		ctlMoi: 'moi',
		valLuu: "Lưu",
		valSua: "Sửa",
		ajaxLuu: "",
		ajaxSua: "",
		keyCode: "",
		defaultVal: "- Select One -",
		valMesComplete: "Đã Hoàn thành",
		valueMesLuu: "Lưu thành công.",
		valueErLuu: "Lưu thất bại.",
		valueMesSua: "Cập nhật thành công.",
		valueErSua: "Cập nhật thất bại.",
		valueMesXoa: "Xóa thành công.",
		valueErXoa: "Xóa thất bại.",
		valueConfirm: "Xác nhận.",
		readMKV: true,
		ctlSaveOnFrame: function(opt) {
			var list = "&" + opt.idkhoachinh + "=" + $.mkv.queryString(opt.idkhoachinh);
			eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('5(0.2){$(0.3+" [4=1]").6(7(){8+=$(9).a()})}',11,11,'opt|true|readMKV|Frame|mkv|if|each|function|list|this|readControl'.split('|'),0,{}))
			return list;
		},
		ctlSaveOnTable: function(i, opt) {
			var list = "";
			eval(function(p,a,c,k,e,r){e=function(c){return c.toString(a)};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}('4(1.7){$("#"+1.3).0("5:6("+2+")").0("[8=9]").a(b(){c+=$(d).e()})}',15,15,'find|opt|i|tablename|if|tr|eq|readMKV|mkv|true|each|function|list|this|readControl'.split('|'),0,{}))
			return list;
		}
	},
    $.mkv={controlfind:"",Save:{run:function(control,opt,before,after,afterUpdate){if(control.attr("id")==opt.ctlLuu)$.mkv.Them(control,opt,before,after);if(control.attr("id")=="_"+opt.ctlLuu)$.mkv.CapNhat(control,opt,afterUpdate)}},flagtemp:true,row1:1,row2:"",queryString:function(param,value){if(value!=null){var preUrl="",postUrl="",newUrl="",url=location.hash,start=url.indexOf(param+"=");if(-1<start){var end=url.indexOf("=",start),startRest=url.indexOf("&",start);postUrl="";preUrl=url.substring(0,end)+"="+value;-1<startRest&&(postUrl=url.substring(startRest))}else{var delimeter="";preUrl=url;delimeter=0<(url.indexOf("#")!=-1)?"&":"";postUrl=delimeter+param+"="+value}newUrl=preUrl+postUrl;location.hash=newUrl}else{param=param.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");var regexS="[\\?&#]"+param+"=([^&#]*)";var regex=new RegExp(regexS);var results=regex.exec(window.location.href);if(results==null)return"";else return results[1]}},New:function(options){$.mkv.removeQueryString(options.idkhoachinh);if($("#"+options.ctlXoa).length!=0)$("#"+options.ctlXoa).hide();if($("#_"+options.ctlLuu).length!=0){$("#_"+options.ctlLuu).attr("id",options.ctlLuu);$("#"+options.ctlLuu).val(options.valLuu)}$.mkv.permisionLuu(options)},removeQueryString:function(param){if(location.hash.indexOf(param)!=-1){var prePosition="#";if(location.hash.indexOf("&"+param)!=-1)prePosition="&";location.hash=location.hash.replace(prePosition+param+"="+$.mkv.queryString(param),"")}},Them:function(control,opt,before,after){if(!$.isNullOrEmpty(before))if(!before())return false;control.attr("disabled",true);$.mkv.loading();if(location.hash.indexOf(opt.idkhoachinh)!=-1){$.ajax({type:"GET",cache:false,dataType:"text",url:(opt.ajaxSua==""?opt.ajax:opt.ajaxSua)+opt.ctlSaveOnFrame(opt),success:function(value){if($("#diverror").length>0)$.mkv.closeMyerror("#diverror");$.mkv.myalert(opt.valueMesSua,2000,"success");$.mkv.queryString(opt.idkhoachinh,value);control.attr("id","_"+opt.ctlLuu);control.val(opt.valSua);$("#"+opt.ctlXoa).show();$.mkv.ExtendtionLuu(true,opt);setTimeout(function(){$("#"+opt.ctlMoi).filter(':visible').filter(':enabled').focus()},100);$("#loadingAjax").remove();control.attr("disabled",false);if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){$("#loadingAjax").remove();control.attr("disabled",false);$('form:not(.filter) :input:visible:first').filter(':visible').filter(':enabled').focus();if(data.responseText.length)$.mkv.myerror(data.responseText);else $.mkv.myerror(opt.valueErSua)}})}else{$.ajax({type:"GET",cache:false,dataType:"text",url:(opt.ajaxLuu==""?opt.ajax:opt.ajaxLuu)+opt.ctlSaveOnFrame(opt),success:function(value){if($("#diverror").length>0)$.mkv.closeMyerror("#diverror");$.mkv.myalert(opt.valueMesLuu,2000,"success");$.mkv.queryString(opt.idkhoachinh,value);control.attr("id","_"+opt.ctlLuu);control.val(opt.valSua);$("#"+opt.ctlXoa).show();$.mkv.ExtendtionLuu(true,opt);setTimeout(function(){$("#"+opt.ctlMoi).filter(':visible').filter(':enabled').focus()},100);$("#loadingAjax").remove();control.attr("disabled",false);if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){$("#loadingAjax").remove();control.attr("disabled",false);$('form:not(.filter) :input:visible:first').focus();if(data.responseText.length)$.mkv.myerror(data.responseText);else $.mkv.myerror(opt.valueErLuu)}})}},BindDuLieuTimKiem:function(opt,before,after){if(!$.isNullOrEmpty(before))if(!before())return false;$.ajax({type:"GET",cache:false,dataType:"xml",url:opt.ajax,success:function(data){$(opt.Frame+" [mkv=true]").each(function(){var value=$(data).find("#"+$(this).attr("id")).text();if($(this).is("input")||$(this).is("select")||$(this).is("textarea")){switch($(this).attr("type")){case"checkbox":(value.toLowerCase()=="true"||value.toLowerCase()=="1")?$(this).attr("checked",true):$(this).attr("checked",false);break;case"radio":($(this).val().toLowerCase()==value.toLowerCase())?$(this).attr("checked",true):$(this).attr("checked",false);break;default:$(this).val(value);break}}else if($(this).is("span"))$(this).text(value);else $(this).html(value)});$(data).find("#"+opt.idkhoachinh+"").each(function(){$.mkv.XoaControlAfterFind($(this).text(),opt)});if(!$.isNullOrEmpty(after))after(data)},error:function(data){$.mkv.myerror(data.responseText)}})},CapNhat:function(control,opt,after){control.attr("id",opt.ctlLuu);control.val(opt.valLuu);$.mkv.ExtendtionLuu(false,opt);if(!$.isNullOrEmpty(after))after(control)},LoadTimKiem:function(control,opt,before,after){if($(control).attr("type")==="button"){$.mkv.controlfind=opt.ctlSaveOnFrame(opt);$.mkv.Find(control,opt,before,after)}else if($(control).is("a"))$.mkv.Find(control,opt,before,after);else{$(control).keydown(function(event){if(opt.keyCode==""){if($(control).attr("mkv")!=null&&$(control).attr("mkv")=="true"){$.mkv.controlfind="&"+$(control).attr("id")+"="+encodeURIComponent($(control).val());switch(event.keyCode){case 113:$.mkv.Find(control,opt,before,after);break;case 27:if($("#divTimKiem").length!=0)$.mkv.dongtimkiem(control.attr("id"));break;case 13:case 37:case 38:case 39:case 40:break;default:if($("#divTimKiem").length!=0)$.mkv.Find(control,opt,before,after);break}}}else{$.mkv.controlfind="&"+$(control).attr("id")+"="+encodeURIComponent($(control).val());switch(event.keyCode){case 27:if($("#divTimKiem").length!=0)$.mkv.dongtimkiem(control.attr("id"));break;case opt.keyCode:event.preventDefault();$.mkv.Find(control,opt,before,after);break;case 37:case 38:case 39:case 40:break;default:if($("#divTimKiem").length!=0)$.mkv.Find(control,opt,before,after);break}}}).blur(function(){$(this).unbind("keydown");$(this).unbind("blur")})}},dongtimkiem:function(control){$.mkv.closeDivTimKiem();$.mkv.runCloseTimKiem();$("#"+control).filter(':visible').filter(':enabled').focus()},eventesc:function(control,controlTimKiem){if(event.keyCode===27){$.mkv.closeDivTimKiem();$.mkv.runCloseTimKiem();$("#"+controlTimKiem).filter(':visible').filter(':enabled').focus()}},closeDivTimKiem:function(){$("#divTimKiem").animate({'width':0,'height':0,'top':$(window).height()/2},400,function(){$(this).remove()})},runCloseTimKiem:function(){},scrollyactive:function(control){$("#"+control).filter(':visible').filter(':enabled').focus()},full:true,styles:"",fullscreens:function(control){if($.mkv.full){$.mkv.styles=$(control).attr("style");$(control).animate({'top':'0','left':'0','width':$(window).width()-(document.body.offsetWidth - document.body.clientWidth),'height':$(window).height()-(document.body.offsetHeight - document.body.clientHeight),'opacity':'10'},'slow').draggable('disable');$.mkv.full=false}else{$(control).attr('style',$.mkv.styles);$.mkv.full=true;$(control).draggable('enable')}},Find:function(control,opt,before,after){if(!$.isNullOrEmpty(before))if(!before())return false;if(!opt.showPopup){if($.isNullOrEmpty(before))$.mkv.loading();$.ajax({type:"GET",cache:false,url:opt.ajax+$.mkv.controlfind,dataType:"text",success:function(value){if($("#loadingAjax").length>0)$("#loadingAjax").remove();if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){if($("#loadingAjax").length>0)$("#loadingAjax").remove();$.mkv.myerror(data.responseText)}})}else{if($("#divTimKiem").length==0){$("<div id=\"divTimKiem\" ondblclick='$.mkv.fullscreens(this);' onmove=\"$.mkv.scrollyactive('"+$(control).attr("id")+"')\" onkeyup=\"$.mkv.eventesc(this,'"+$(control).attr("id")+"');\" />").css({'background':'#efefef','margin':'auto','top':'20%','left':'15%','position':'fixed','display':'none','border':'1px solid #4297d7','width':opt.width,'height':opt.height,'padding':'0px 2px 30px 0px','z-index':'5000'}).appendTo(document.body);$("#divTimKiem").animate({height:'show',right:'+100',top:'+200',opacity:'show'},'slow').draggable({handle:'#divTimKiemTitle'}).resizable();$("<p id='divTimKiemTitle' />").css({'border':'1px solid #fcfdfd','background':'#2191c0 url(../images/ui-bg_gloss-wave_75_2191c0_500x100.png) 50% 50% repeat-x','color':'#eaf5f7','cursor':'move','font-weight':'bold','float':'left','width':'100%','padding':'2px 0px 3px 0px'}).html("&nbsp;&nbsp;&nbsp;"+opt.title).appendTo("#divTimKiem");$("<p onscroll=\"$.mkv.scrollyactive('"+$(control).attr("id")+"')\" id=\"divSetTimKiem\" />").css({'background':'#fff','width':'99.5%','height':'97%','float':'right','margin-top':'-11px','overflow':'scroll','text-align':'center','border':'1px solid #cfcfcf'}).appendTo("#divTimKiem");$("<img onclick=\"$.mkv.dongtimkiem('"+$(control).attr("id")+"');\" src=\"../images/close.gif\" />").css({'float':'right','cursor':'pointer','padding-right':'5px','top':'2px','right':'0','position':'absolute'}).appendTo("#divTimKiemTitle")}$("#divSetTimKiem").html("Đang tìm dữ liệu ...");$.ajax({type:"GET",cache:false,dataType:"text",url:opt.ajax+$.mkv.controlfind,success:function(value){$("#divSetTimKiem").html(value);if($("#divSetTimKiem").find("table").find("tr").length<3)$("#divSetTimKiem").find("table").find("tr").eq(1).click();if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){$.mkv.closeDivTimKiem();if(data.responseText.length)$.mkv.myerror(data.responseText);else $.mkv.myalert("Không tìm thấy dữ liệu !",2000,"info")}})}},XoaTrangData:function(opt){opt=$.extend({},$.defaults,opt);$(opt.Frame+' input[type="text"],'+opt.Frame+' input[type="password"],'+opt.Frame+' input[type="hidden"],'+opt.Frame+' textarea').each(function(){if($(this).attr("clearVal")==null)$(this).val("");else if($(this).attr("clearVal")!="false")$(this).val("")});$(opt.Frame+' input[type="checkbox"]').each(function(){if($(this).attr("clearVal")==null)$(this).attr("checked",false);else if($(this).attr("clearVal")!="false")$(this).attr("checked",false)});$(opt.Frame+' select').each(function(){if($(this).attr("clearVal")==null)$(this).find("option:eq(0)").attr("selected","selected");else if($(this).attr("clearVal")!="false")$(this).find("option:eq(0)").attr("selected","selected")})},loading:function(){$("BODY").append('<p id="loadingAjax" style="position:fixed;width:100%;top:0;left:0;right:0;bottom:0;z-index:2000;height:100%;opacity:0.2;filter:alpha(opacity=20);"><img src="../images/loading.gif" style="top:45%;left:45%;position:absolute"/></p>')},Xoakhoachinh:function(control,opt,before,after){if(!$.isNullOrEmpty(before))if(!before())return false;$(control).attr('disabled',true);$.mkv.loading();$.ajax({type:"GET",cache:false,dataType:"text",url:opt.ajax+"&"+opt.idkhoachinh+"="+$.mkv.queryString(opt.idkhoachinh),success:function(value){if($("#diverror").length>0)$.mkv.closeMyerror("#diverror");$.mkv.myalert(opt.valueMesXoa,2000,"success");$.mkv.New(opt);$.mkv.XoaTrangData(opt);$.mkv.ExtendtionLuu(false,opt);$(control).attr('disabled',false);$("#loadingAjax").remove();if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){$(control).attr('disabled',false);$("#loadingAjax").remove();$(control).filter(':visible').filter(':enabled').focus();if(data.responseText.length)$.mkv.myerror(data.responseText);else $.mkv.myerror(opt.valueErXoa)}})},focusLuu:function(opt){$("#_"+opt.ctlLuu).filter(':visible').filter(':enabled').focus()},XoaControlAfterFind:function(valuekhoachinh,opt){$.mkv.queryString(opt.idkhoachinh,valuekhoachinh);if($("#"+opt.ctlLuu).length!=0){$("#"+opt.ctlLuu).attr("id","_"+opt.ctlLuu);$("#_"+opt.ctlLuu).val(opt.valSua)}$("#"+opt.ctlXoa).show();$.mkv.closeDivTimKiem();$.mkv.ExtendtionLuu(true,opt);$.mkv.permisionSua(opt);$.mkv.focusLuu(opt)},ExtendtionLuu:function(flag,opt){if(flag==true){$(opt.Frame+' input[type="text"],'+opt.Frame+' input[type="checkbox"],'+opt.Frame+' input[type="radio"],'+opt.Frame+' select,'+opt.Frame+' textarea').each(function(){$(this).attr('disabled',true)})}else{$(opt.Frame+' input[type="text"],'+opt.Frame+' input[type="checkbox"],'+opt.Frame+' input[type="radio"],'+opt.Frame+' select,'+opt.Frame+' textarea').each(function(){$(this).attr('disabled',false)});$('form:not(.filter) :input:visible:first').focus()}},binddroplist:function(control,opt,before,after){if(!$.isNullOrEmpty(before))if(!before())return false;var droplist=$(control);var options="";if(droplist.prop)options=droplist.prop('options');else options=droplist.attr('options');options[options.length]=new Option("loading...","");$.ajax({type:"GET",cache:false,dataType:"text",url:opt.ajax,success:function(value){options.length=0;if($.trim(opt.defaultVal)!="")options[options.length]=new Option(opt.defaultVal,"");var mangValue=value.split("\r\n");$.each(mangValue,function(){var val=this.split("|")[1];var text=this.split("|")[0];options[options.length]=new Option(text,val)});droplist.find("option:last").remove();if(!$.isNullOrEmpty(after))after(value,control)},error:function(data){$.mkv.myerror(data.responseText)}})},chuyenphim:function(control){$(control).keydown(function(event){if(event.keyCode==13){$.mkv.nextOnTabIndex(control).focus()}}).blur(function(){$(this).unbind("keydown");$(this).unbind("blur")})},nextOnTabIndex:function(element){var fields=$($('form').find('a[href], button, input, select, textarea').filter(':visible').filter(':enabled').toArray().sort(function(a,b){return((a.tabIndex>0)?a.tabIndex:1000)-((b.tabIndex>0)?b.tabIndex:1000)}));return fields.eq((fields.index(element)+1)%fields.length)},myalert:function(message,time,clas){if(message.indexOf("script language")!=-1)message=message.replace(new RegExp("script language"),"");if($("#divalert").length==0){$("BODY").append("<div id=\"divalert\" class="+clas+">"+message+"</div>");var top=(($(window).height()/2)-($("#divalert").outerHeight()/2));var left=(($(window).width()/2)-($("#divalert").outerWidth()/2));$("#divalert").animate({top:top+'px',left:left+'px'},'slow').draggable();setTimeout(function(){$("#divalert").animate({top:'350',opacity:'0.5'},'fast',function(){$(this).animate({top:'1000',left:'1000',opacity:'hide'},'slow',function(){$(this).remove()})})},time)}else $("#divalert").append("<br/>"+message)},myerror:function(message){if(message.indexOf("script language")!=-1)message=message.replace(new RegExp("script language"),"");if($("#diverror").length==0){$("BODY").append("<div id=\"diverror\" class=\"error\" style=\"cursor:pointer;\" onclick=\"$.mkv.closeMyerror(this);\">"+message+"</div>");var top=(($(window).height()/2)-($("#diverror").outerHeight()/2));var left=(($(window).width()/2)-($("#diverror").outerWidth()/2));$("#diverror").animate({top:top+'px',left:left+'px'},'slow').draggable()}else $("#diverror").append("<br/>"+message)},closeMyerror:function(obj){$(obj).animate({top:'350',opacity:'0.5'},'fast',function(){$(this).animate({top:'1000',left:'1000',opacity:'hide'},'slow',function(){$(this).remove()})})},checkchuyenphim:true,tempWidth:null,chuyendong:function(control){if($.mkv.checkchuyenphim){var tablename=$(control).parents("table");$(control).keydown(function(event){var cellNumber=$(control).parent().index();var rowNumber=$(control).parent().parent().index();switch(event.keyCode){case 40:if($.trim(tablename.find("tr").eq(rowNumber+1).find("td").eq(1).text()).length<1&&tablename.find("tr").eq(rowNumber).find("td").eq(cellNumber).find('select').length<1)$.mkv.themDongTable(tablename.attr("id"));var up=tablename.find("tr").eq(rowNumber+1).find("td").eq(cellNumber);if(up.find("input").length!=0)up.find("input").filter(':visible').filter(':enabled').focus();if(up.find("a").length!=0)up.find("a").filter(':visible').filter(':enabled').focus();break;case 38:if(tablename.find("tr").eq(rowNumber-1).find("td").eq(cellNumber).find("input").length!=0)tablename.find("tr").eq(rowNumber-1).find("td").eq(cellNumber).find("input").filter(':visible').filter(':enabled').focus();if(tablename.find("tr").eq(rowNumber-1).find("td").eq(cellNumber).find("a").length!=0)tablename.find("tr").eq(rowNumber-1).find("td").eq(cellNumber).find("a").filter(':visible').filter(':enabled').focus();var flagrow=false;for(var i=0;i<tablename.find("tr").eq(rowNumber).find("td").length;i++){var indexd=tablename.find("tr").eq(rowNumber).find("td").eq(i).find('input[type="text"]');if(indexd.length!=0&&indexd.val().length>0&&indexd.val()!="0"&&indexd!="0.0"){flagrow=true;return}}if(flagrow==false&&rowNumber>1&&tablename.find("tr").eq(rowNumber).find("td").eq(cellNumber).find('select').length<1)tablename.find("tr").eq(rowNumber).remove();break;default:break}}).blur(function(){$(this).unbind("keydown");$(this).unbind("blur")})}},themDongTable:function(tableName){var tableNames=$("#"+tableName).find("tr").length;var money=$("#"+tableName).find("tr").eq(1).clone().find('input,select,a,span').attr("disabled",false).each(function(){$(this).attr({'value':function(){return""},'checked':function(){return false}})}).end();$("#"+tableName).find("tr").eq(1).find('input[type="text"]').each(function(){var focu=$(this).prop('onfocus')!=null?$(this).prop('onfocus'):$(this).attr('onfocus');if(focu!=null){var chuoi=$.trim(focu);if(chuoi.indexOf("{")!=-1)money.find("#"+$(this).attr("id")).attr('onfocus',chuoi.substring(chuoi.indexOf("{")+2,chuoi.length-2));else money.find("#"+$(this).attr("id")).attr('onfocus',chuoi)}});money.find("[id^=delete_result]").remove();money="<tr>"+money.html()+"</tr>";if($.trim(document.getElementById(tableName).rows[tableNames-1].cells[0].innerText).length<1){$("#"+tableName).find("tr").eq(tableNames-2).after(money);tableNames=tableNames+1;$("#"+tableName).find("tr").eq(tableNames-2).find("td").eq(0).html(eval($("#"+tableName).find("tr").eq(tableNames-3).find("td").eq(0).html())+1);if($("#"+tableName).find("tr").eq(tableNames-2).find("td").eq(0).html()=="NaN"){$("#"+tableName).find("tr").eq(tableNames-3).find("td").eq(0).html(1);$("#"+tableName).find("tr").eq(tableNames-2).find("td").eq(0).html(2)}$.mkv.afterThemDong(tableName,tableNames-3)}else{$("#"+tableName).find("tr").eq(tableNames-3).find("td").eq(0).after(money);tableNames=tableNames+1;$("#"+tableName).find("tr").eq(tableNames-3).find("td").eq(0).html(eval($("#"+tableName).find("tr").eq(tableNames-4).find("td").eq(0).html())+1);$.mkv.afterThemDong(tableName,tableNames-4)}},afterThemDong:function(tableName,dongso){},chuyenformout:function(control){$(control).css({'position':'','margin-top':'0','margin-left':'0','width':$.mkv.tempWidth})},permisionLuu:function(options){if($("#"+options.ctlLuu).attr("add")=="False")$("#"+options.ctlLuu).attr("disabled",true).css("background","#cfcfcf");else $("#"+options.ctlLuu).attr("disabled",false).css("background","#648ccc")},permisionSua:function(opt){if($("#_"+opt.ctlLuu).attr("edit")=="False")$("#_"+opt.ctlLuu).attr("disabled",true).css("background","#cfcfcf");else $("#_"+opt.ctlLuu).attr("disabled",false).css("background","#648ccc")},jTable:{savewithSubmit:function(control,opt,after){if(control.attr("id")!="_tempnEo"){$("[id^="+control.attr("id")+"]").each(function(){$(this).attr("id","_tempnEo").val(opt.valueBtLuu.split('/')[1])});$.mkv.jTable.save(control,opt,after);$.mkv.flagtemp=true}else{$("[id^="+control.attr("id")+"]").each(function(){$(this).attr("id","nEo").val(opt.valueBtLuu.split('/')[0])});$.mkv.flagtemp=false}},save:function(control,opt,after){if($("#loadingAjax").length<1)$.mkv.loading();$.ajax({type:"GET",cache:false,dataType:"text",url:opt.ajax+opt.ctlSaveOnTable($.mkv.row1,opt),success:function(value){$("#"+opt.tablename).find("tr").eq($.mkv.row1).css("background-color","");$("#"+opt.tablename).find("tr").eq($.mkv.row1).find("[id="+opt.idkhoachinh+"]").val(value);$("#"+opt.tablename).find("tr").eq($.mkv.row1+1).css("background-color","#0066ff");$("#"+opt.tablename).find("tr").eq($.mkv.row1).css("background-color","");$.mkv.jTable.behindLuuTable1(control,opt,after)},error:function(data){$("#"+opt.tablename).find("tr").eq($.mkv.row1).css("background-color","yellow");if($.mkv.row1>=$("#"+opt.tablename).find("tr").length-1)$("#"+opt.tablename).find("tr").eq($.mkv.row1).css("background-color","");$.mkv.jTable.behindLuuTable1(control,opt,after)}})},xoa:function(control,opt,before,after){var khoachinh=$(control.parents("table")).find("tr").eq(control.parent().parent().index()).find("[id="+opt.idkhoachinh+"]").val();if(khoachinh.length>0){if(!$.isNullOrEmpty(before))if(!before())return false;$.mkv.loading();$.ajax({type:"GET",cache:false,dataType:"text",url:opt.ajax+"&"+opt.idkhoachinh+"="+khoachinh,success:function(data){if($("#diverror").length>0)$.mkv.closeMyerror("#diverror");$.mkv.myalert(opt.valueMesXoa,2000,"success");$(control.parents("table")).find("tr").eq(control.parent().parent().index()).remove();$("#loadingAjax").remove();if(!$.isNullOrEmpty(after))after(data,control)},error:function(data){$("#loadingAjax").remove();if(data.responseText.length)$.mkv.myerror(data.responseText);else $.mkv.myerror(opt.valueErXoa)}})}else $(control.parents("table")).find("tr").eq(control.parent().parent().index()).remove()},behindLuuTable2:function(control,opt,after){if(control!=null){$("[id^="+$(control).attr("id")+"]").each(function(){$(this).attr("id","nEo").val(opt.valueBtLuu.split('/')[0])})}$("#loadingAjax").remove();$("#"+opt.tablename).find("tr").eq($.mkv.row1+1).css("background-color","");$.mkv.row1=1;$.mkv.myalert(opt.valMesComplete,2000,"info");if(!$.isNullOrEmpty(after))after(control)},behindLuuTable1:function(control,opt,after){if($.mkv.row2!=""){if($.mkv.row1<$.mkv.row2&&$.mkv.flagtemp==true){$.mkv.row1=$.mkv.row1+1;$.mkv.jTable.save(control,opt,after);return}}else{if($.mkv.row1<$("#"+opt.tablename).find("tr").length-2&&$.mkv.flagtemp==true){$.mkv.row1=$.mkv.row1+1;$.mkv.jTable.save(control,opt,after);return}}$.mkv.jTable.behindLuuTable2(control,opt,after)}},moveUpandDown:function(idtable){var currentRow=1;var tr="";$(document).keydown(function(event){if($(idtable).attr("id")!=null){if(tr!=$(idtable).find("tr"))tr=$(idtable).find("tr");tr.eq(currentRow).css("background-color","");tr.eq(currentRow).css("color","gray");if(event.keyCode==38){if(currentRow<=1)currentRow=1;else currentRow=currentRow-1;tr.eq(currentRow).css("background-color","#f6ebcd");tr.eq(currentRow).css("color","green");$(idtable).parent().scrollTop($(idtable).parent().scrollTop()-(tr.eq(2).height()+1))}if(event.keyCode==40){if(currentRow>=tr.length-1)currentRow=tr.length-1;else currentRow=currentRow+1;tr.eq(currentRow).css("background-color","#f6ebcd");tr.eq(currentRow).css("color","green");$(idtable).parent().scrollTop($(idtable).parent().scrollTop()+(tr.eq(2).height()+1))}if(event.keyCode==13)tr.eq(currentRow).click()}else currentRow=0}).blur(function(){$(this).unbind("keydown");$(this).unbind("blur")})},checkluu:function(control){var tablename=control.parents("table");if(control.checked==true){if($.mkv.row1==1)$.mkv.row1=control.parent().parent().index();else{if($.mkv.row2==tablename.find("tr").length||$.mkv.row2=="")$.mkv.row2=control.parent().parent().index();else{control.checked=false;alert("Đã chọn dòng "+$.mkv.row1+" --> "+$.mkv.row2+" !")}}}else{if($.mkv.row1==control.parent().parent().index())$.mkv.row1=1;else $.mkv.row2=tablename.find("tr").length}if($.mkv.row1>$.mkv.row2&&$.mkv.row2!=""){var tam1=$.mkv.row2;$.mkv.row2=$.mkv.row1;$.mkv.row1=tam1}}};$.getCharacter=function(el){if(el.selectionStart){return el.selectionStart}else if(document.selection){el.focus();var r=document.selection.createRange();if(r==null){return 0}var re=el.createTextRange(),rc=re.duplicate();re.moveToBookmark(r.getBookmark());rc.setEndPoint('EndToStart',re);return rc.text.length}return 0};$.setFocusCharacter=function(obj,caretPos){var elem=obj;if(elem!=null){if(elem.createTextRange){var range=elem.createTextRange();range.move('character',caretPos);range.select()}else{if(elem.selectionStart){elem.focus();elem.setSelectionRange(caretPos,caretPos)}else elem.focus()}}};$.TestDate=function(t){var ngay=t;if(t.value.length>0){var arrngay=ngay.value.split('/');if(arrngay.length==3){if(!$.isDate(ngay.value)){t.focus()}else{if($("#diverror").length>0){$.mkv.closeMyerror("#diverror")}}}else{var ngaymoi=ngay.value.charAt(0)+ngay.value.charAt(1)+'/'+ngay.value.charAt(2)+ngay.value.charAt(3)+'/'+ngay.value.charAt(4)+ngay.value.charAt(5)+ngay.value.charAt(6)+ngay.value.charAt(7);t.value=ngaymoi;if(!$.isDate(t.value)){t.focus()}else{if($("#diverror").length>0){$.mkv.closeMyerror("#diverror")}}}}};$.isDate=function(dateStr){var datePat=/^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;var matchArray=dateStr.match(datePat);if(matchArray==null){$.mkv.myerror("Ngày tháng không hợp lệ: "+dateStr);return false}var day=matchArray[1];var month=matchArray[3];var year=matchArray[5];var flag=true;if(month<1||month>12){$.mkv.myerror("Tháng phải giữa 1 và 12.");flag=false}if(day<1||day>31){$.mkv.myerror("Ngày phải giữa 1 và 31 ngày.");flag=false}if((month==4||month==6||month==9||month==11)&&day==31){$.mkv.myerror("Tháng "+month+" không có 31 ngày!");flag=false}if(month==2){var isleap=(year%4==0&&(year%100!=0||year%400==0));if(day>29||(day==29&&!isleap)){$.mkv.myerror("Tháng 2 năm "+year+" không có "+day+" ngày!");flag=false}}return flag};$.textAtCursor=function(textArea,text){if(textArea.setSelectionRange){var pos=$.getCharacter(textArea)+1;textArea.value=textArea.value.substring(0,textArea.selectionStart)+text+textArea.value.substring(textArea.selectionStart,textArea.selectionEnd)+textArea.value.substring(textArea.selectionEnd,textArea.value.length);textArea.focus();textArea.setSelectionRange(pos,pos)}else if(document.selection&&document.selection.createRange){textArea.focus();var range=document.selection.createRange();range.text=text+range.text}};$.isNullOrEmpty=function(value){if($.trim(value)==="")return true;else if(value===null)return true;else if(value===undefined)return true;else return false};
    chuyendong = function(control) {
		$.mkv.chuyendong(control);
	};
	chuyenformout = function(control) {
		$.mkv.chuyenformout(control);
	};
	chuyenphim = function(control) {
		$.mkv.chuyenphim(control);
	};
})(jQuery);