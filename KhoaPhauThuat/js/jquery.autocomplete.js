var hostabc = false;
var layfirst = false;
$(document).ready(function () {
    $(".down_select").each(function(){
        $(this).after($("<img onmouseout='this.style.backgroundColor=\"\";this.style.border=\"0\";' onmouseover='this.style.backgroundColor=\"#ece9d8\"' src='../images/asc.gif' style='position:absolute;margin-left:-25px;margin-top:6px;padding:5px 0 5px 0' onclick=\"$('#"+$(this).attr("id")+"').abc();\"/>"));
    });
    $(".down_select_hover").live('hover',function(){
        $(this).after($("<img onmouseout='this.style.backgroundColor=\"\";this.style.border=\"0\";' onmouseover='this.style.backgroundColor=\"#ece9d8\"' src='../images/asc.gif' style='position:absolute;margin-left:-25px;margin-top:6px;padding:5px 0 5px 0' onclick=\"$('#"+$(this).attr("id")+"').abc();\"/>"));
    });
    $("table .down_select").live('hover',function(){
        $(this).after($("<img onmouseout='this.style.backgroundColor=\"\";this.style.border=\"0\";' onmouseover='this.style.backgroundColor=\"#ece9d8\"' src='../images/asc.gif' style='position:absolute;margin-left:-25px;margin-top:6px;padding:5px 0 5px 0;border:none;' onclick=\"$(this).parents('table').find('tr').eq($(this).parent().parent().index()).find('#"+$(this).attr("id")+"').abc();\"/>"));
    });
});
function laydautien(obj,urls) {
    if(layfirst)
	{
	    $.ajax({
			    type:"GET",
			    url: urls,
			    success: function(datas) {
			        if($(obj).parents("table").attr("id") == null){
			            $("#"+$(obj).attr("id").split('mkv_')[1]).val(datas.split('\r\n')[0].split('|')[1]);
			        }else{
			            $(obj).parents('table').find('tr').eq($(obj).parent().parent().index()).find("#"+$(obj).attr("id").split('mkv_')[1]).val(datas.split('\r\n')[0].split('|')[1]);    
			        }
				    $(obj).val(datas.split('\r\n')[0].split('|')[0]);
			    }
        });
        layfirst = false;
	}
}
;(function($) {
$.fn.extend({
	autocomplete: function(urlOrData, options) {
		var isUrl = typeof urlOrData == "string";
		options = $.extend({}, $.Autocompleter.defaults, {
			url: isUrl ? urlOrData : null,
			data: isUrl ? null : urlOrData,
			delay: isUrl ? $.Autocompleter.defaults.delay : 10,
			max: options && !options.scroll ? 10 : 100
		}, options);
		options.highlight = options.highlight || function(value) { return value; };
		options.formatMatch = options.formatMatch || options.formatItem;
		return this.each(function() {
		    laydautien(this,urlOrData);
			new $.Autocompleter(this, options);
		});
		return this.each(function() {
			new $.Autocompleter(this, options);
		});
	},
	result: function(handler) {
		return this.bind("result", handler);
	},
	search: function(handler) {
		return this.trigger("search", [handler]);
	},
	flushCache: function() {
		return this.trigger("flushCache");
	},
	setOptions: function(options){
		return this.trigger("setOptions", [options]);
	},
	unautocomplete: function() {
		return this.trigger("unautocomplete");
	},
	abc:function (options) {
		if($(this).is(":disabled"))return;
	    this.focus();	
	    hostabc = true;
	    return this.trigger("getAll");
	}
});
$.Autocompleter = function(input, options) {
	var KEY = {
		UP: 38,
		DOWN: 40,
		DEL: 46,
		TAB: 9,
		RETURN: 13,
		ESC: 27,
		COMMA: 188,
		PAGEUP: 33,
		PAGEDOWN: 34,
		BACKSPACE: 8
	};
	var $input = $(input).attr("autocomplete", "off").addClass(options.inputClass);
	var timeout;
	var previousValue = "";
	var cache = $.Autocompleter.Cache(options);
	var hasFocus = 0;
	var lastKeyPressCode;
	var config = {
		mouseDownOnSelect: false
	};
	var select = $.Autocompleter.Select(options, input, selectCurrent, config);
	var blockSubmit;
	$.browser.opera && $(input.form).bind("submit.autocomplete", function() {
		if (blockSubmit) {
			blockSubmit = false;
			return false;
		}
	});
	$input.bind(($.browser.opera ? "keypress" : "keydown") + ".autocomplete", function(event) {
		hasFocus = 1;
		lastKeyPressCode = event.keyCode;
		switch(event.keyCode) {
			case KEY.UP:
				event.preventDefault();
				if ( select.visible() ) {
					select.prev();
				} else {
					onChange(0, true);
				}
				break;
			case KEY.DOWN:
				event.preventDefault();
				if ( select.visible() ) {
					select.next();
				} else {
					onChange(0, true,true);
				}
				break;
			case KEY.PAGEUP:
				event.preventDefault();
				if ( select.visible() ) {
					select.pageUp();
				} else {
					onChange(0, true);
				}
				break;
				
			case KEY.PAGEDOWN:
				event.preventDefault();
				if ( select.visible() ) {
					select.pageDown();
				} else {
					onChange(0, true);
				}
				break;
			case options.multiple && $.trim(options.multipleSeparator) == "," && KEY.COMMA:
			case KEY.TAB:
				if( selectCurrent() ) {
					event.preventDefault();
					blockSubmit = true;
					return false;
				}
				break;
			case KEY.RETURN:
				if( !selectCurrent() && options.isEnterFind)
				{				
					event.preventDefault();
					if ( select.visible() ) {
						select.prev();
					} else {
						onChange(0, true,true);
					}
				}
				else if( selectCurrent() ) {
					event.preventDefault();
					blockSubmit = true;
					return false;
				}
				break;
				
			case KEY.ESC:
				select.hide();
				break;
				
			default:
				clearTimeout(timeout);
				timeout = setTimeout(onChange, options.delay);
				break;
		}
	}).focus(function(){
		hasFocus++;
		if($.browser.msie){
			if (hostabc)
				{
					onChange(0, true);
				}
				hostabc = false;
		    }
	}).blur(function() {
		if($.trim($input.val()).length < 1){
	        if($input.parents("table").attr("id") == null){
		        $("#"+$input.attr("id").replace('mkv_','')+"").val('');
		    }else{
		        $input.parents('table').find('tr').eq($input.parent().parent().index()).find("#"+$input.attr("id").replace('mkv_','')+"").val('');
		    }
		}
		hasFocus = 0;
		if (!config.mouseDownOnSelect) {
			hideResults();
		}
	}).click(function() {
		if ( hasFocus++ > 1 && !select.visible() ) {
			onChange(0, true);
		}
	}).bind("search", function() {
		var fn = (arguments.length > 1) ? arguments[1] : null;
		function findValueCallback(q, data) {
			var result;
			if( data && data.length ) {
				for (var i=0; i < data.length; i++) {
					if( data[i].result.toLowerCase() == q.toLowerCase() ) {
						result = data[i];
						break;
					}
				}
			}
			if( typeof fn == "function" ) fn(result);
			else $input.trigger("result", result && [result.data, result.value]);
		}
		$.each(trimWords($input.val()), function(i, value) {
			request(value, findValueCallback, findValueCallback);
		});
	}).bind("flushCache", function() {
		cache.flush();
	}).bind("setOptions", function() {
		$.extend(options, arguments[1]);
		if ( "data" in arguments[1] )
			cache.populate();
	}).bind("unautocomplete", function() {
		select.unbind();
		$input.unbind();
		$(input.form).unbind(".autocomplete");
	}).bind("getAll", function() {
	    hasFocus++;
	    if(!$.browser.msie){
		    onChange(0, true,true);
		}
    });
	function selectCurrent() {
		var selected = select.selected();
		if( !selected )
			return false;
		var v = selected.result;
		previousValue = v;
		
		if ( options.multiple ) {
			var words = trimWords($input.val());
			if ( words.length > 1 ) {
				var seperator = options.multipleSeparator.length;
				var cursorAt = $(input).selection().start;
				var wordAt, progress = 0;
				$.each(words, function(i, word) {
					progress += word.length;
					if (cursorAt <= progress) {
						wordAt = i;
						return false;
					}
					progress += seperator;
				});
				words[wordAt] = v;
				v = words.join( options.multipleSeparator );
			}
			v += options.multipleSeparator;
		}
		$input.val(v);
		 if($input.parents("table").attr("id") == null){
	        if($("#delete_result_"+$input.attr("id")+"").attr("id") == null)
		        $input.after($("<img style='cursor:pointer;float:right;border:0;position:absolute' id='delete_result_"+$input.attr("id")+"' onclick=\"javascript:$('#"+$input.attr("id")+"').val('');$('#"+$input.attr("id").replace('mkv_','')+"').val('');$(this).remove();\" src='../images/delete_icon.png'/>"));
		}else{
		    if($input.parents("table").find("tr").eq($input.parent().parent().index()).find("#delete_result_"+$input.parents("table").attr("id")+"_"+$input.attr("id")+"").attr("id") == null)
		        $input.after($("<img style='cursor:pointer;float:right;border:0;position:absolute;width:10px' id='delete_result_"+$input.parents("table").attr("id")+"_"+$input.attr("id")+"' onclick=\"javascript:$(this).parents('table').find('tr').eq($(this).parent().parent().index()).find('#"+$input.attr("id")+"').val('');$(this).parents('table').find('tr').eq($(this).parent().parent().index()).find('#"+$input.attr("id").replace('mkv_','')+"').val('');$(this).remove();\" src='../images/delete_icon.png'/>"));
		}
		hideResultsNow();
		$input.trigger("result", [selected.data, selected.value]);
		if ($input.parents("table:first").attr("id") != null) {
                if ($input.parents("table:first").find("tr").eq($($input).parent().parent().index() + 1).find("input:first").length < 1) {
                    if (options.addRow == true)
                        $.mkv.themDongTable($input.parents("table:first"));
                }
         }
		return true;
	}
	function onChange(crap, skipPrevCheck,isFind) {
		if(isFind == null)
			isFind= false;
		if( lastKeyPressCode == KEY.DEL ) 
		{
			select.hide();
			return;
		}
		if(options.isEnterFind && lastKeyPressCode != 13 && !isFind) 
		{
			return;
		}
		//select.hide();
		var currentValue = $input.val();
		if ( !skipPrevCheck && currentValue == previousValue )
			return;
		previousValue = currentValue;
		currentValue = lastWord(currentValue);
		if ( currentValue.length >= options.minChars) {
			$input.addClass(options.loadingClass);
			if (!options.matchCase)
				currentValue = currentValue.toLowerCase();
			request(currentValue, receiveData, hideResultsNow);
		} else {
			stopLoading();
			select.hide();
		}
	};
	function trimWords(value) {
		if (!value)
			return [""];
		if (!options.multiple)
			return [$.trim(value)];
		return $.map(value.split(options.multipleSeparator), function(word) {
			return $.trim(value).length ? $.trim(word) : null;
		});
	}
	function lastWord(value) {
		if ( !options.multiple )
			return value;
		var words = trimWords(value);
		if (words.length == 1) 
			return words[0];
		var cursorAt = $(input).selection().start;
		if (cursorAt == value.length) {
			words = trimWords(value)
		} else {
			words = trimWords(value.replace(value.substring(cursorAt), ""));
		}
		return words[words.length - 1];
	}
	function autoFill(q, sValue){
		if( options.autoFill && (lastWord($input.val()).toLowerCase() == q.toLowerCase()) && lastKeyPressCode != KEY.BACKSPACE ) {
			$input.val($input.val() + sValue.substring(lastWord(previousValue).length));
			$(input).selection(previousValue.length, previousValue.length + sValue.length);
		}
	};
	function hideResults() {
		clearTimeout(timeout);
		timeout = setTimeout(hideResultsNow, 200);
	};
	function hideResultsNow() {
		var wasVisible = select.visible();
		select.hide();
		clearTimeout(timeout);
		stopLoading();
		if (options.mustMatch) {
			$input.search(
				function (result){
					if( !result ) {
						if (options.multiple) {
							var words = trimWords($input.val()).slice(0, -1);
							$input.val( words.join(options.multipleSeparator) + (words.length ? options.multipleSeparator : "") );
						}
						else {
							$input.val( "" );
							$input.trigger("result", null);
						}
					}
				}
			);
		}
	};
	function receiveData(q, data) {
		if ( data && data.length && hasFocus ) {
			stopLoading();
			select.display(data, q);
			autoFill(q, data[0].value);
			select.show();
		} else {
			hideResultsNow();
		}
	};
	function request(term, success, failure) {
		if (!options.matchCase)
			term = term.toLowerCase();
		var data = cache.load(term);
		if (data && data.length) {
			success(term, data);
		} else if( (typeof options.url == "string") && (options.url.length > 0) ){
			var extraParams = {
				timestamp: +new Date()
			};
			$.each(options.extraParams, function(key, param) {
				extraParams[key] = typeof param == "function" ? param() : param;
			});
			$.ajax({
				mode: "abort",
				port: "autocomplete" + input.name,
				dataType: options.dataType,
				url: options.url,
				data: $.extend({
					q: lastWord(term),
					limit: options.max
				}, extraParams),
				success: function(data) {
					var parsed = options.parse && options.parse(data) || parse(data);
					cache.add(term, parsed);
					success(term, parsed);
				}
			});
		} else {
			select.emptyList();
			failure(term);
		}
	};
	function parse(data) {
		var parsed = [];
		var rows = data.split("\n");
		for (var i=0; i < rows.length; i++) {
			var row = $.trim(rows[i]);
			if (row) {
				row = row.split("|");
				parsed[parsed.length] = {
					data: row,
					value: row[0],
					result: options.formatResult && options.formatResult(row, row[0]) || row[0]
				};
			}
		}
		return parsed;
	};
	function stopLoading() {
		$input.removeClass(options.loadingClass);
	};

};
$.Autocompleter.defaults = {
	inputClass: "ac_input",
	resultsClass: "ac_results",
	loadingClass: "ac_loading",
	minChars: 1,
	delay: 400,
	matchCase: false,
	matchSubset: true,
	matchContains:true,
	cacheLength: 10,
	max: 100,
	imgDel:true,
	header:"",	
	mustMatch: false,
	extraParams: {},
	selectFirst: true,
	formatItem: function(row) { return row[0]; },
	formatMatch: null,
	autoFill: false,
	width: 0,
	addRow:false,
	multiple: false,
	multipleSeparator: ", ",
	highlight: function(value, term) {
		return value.replace(new RegExp("(?![^&;]+;)(?!<[^<>]*)(" + term.replace(/([\^\$\(\)\[\]\{\}\*\.\+\?\|\\])/gi, "\\$1") + ")(?![^<>]*>)(?![^&;]+;)", "gi"), "<strong style='color:black;font-weight:bold'>$1</strong>");
	},
    isEnterFind: false,
    scroll: true,
    scrollHeight: 180
};

$.Autocompleter.Cache = function(options) {

	var data = {};
	var length = 0;
	
	function matchSubset(s, sub) {
		if (!options.matchCase) 
			s = s.toLowerCase();
		var i = s.indexOf(sub);
		if (options.matchContains == "word"){
			i = s.toLowerCase().search("\\b" + sub.toLowerCase());
		}
		if (i == -1) return false;
		return i == 0 || options.matchContains;
	};
	
	function add(q, value) {
		if (length > options.cacheLength){
			flush();
		}
		if (!data[q]){ 
			length++;
		}
		data[q] = value;
	}
	function populate(){
		if( !options.data ) return false;
		var stMatchSets = {},
			nullData = 0;
		if( !options.url ) options.cacheLength = 1;
		stMatchSets[""] = [];
		for ( var i = 0, ol = options.data.length; i < ol; i++ ) {
			var rawValue = options.data[i];
			rawValue = (typeof rawValue == "string") ? [rawValue] : rawValue;
			var value = options.formatMatch(rawValue, i+1, options.data.length);
			if ( value === false )
				continue;
			var firstChar = value.charAt(0).toLowerCase();
			if( !stMatchSets[firstChar] ) 
				stMatchSets[firstChar] = [];
			var row = {
				value: value,
				data: rawValue,
				result: options.formatResult && options.formatResult(rawValue) || value
			};
			stMatchSets[firstChar].push(row);
			if ( nullData++ < options.max ) {
				stMatchSets[""].push(row);
			}
		};
		$.each(stMatchSets, function(i, value) {
			options.cacheLength++;
			add(i, value);
		});
	}
	setTimeout(populate, 25);
	function flush(){
		data = {};
		length = 0;
	}
	return {
		flush: flush,
		add: add,
		populate: populate,
		load: function(q) {
			if (!options.cacheLength || !length)
				return null;
			if( !options.url && options.matchContains ){
				var csub = [];
				for( var k in data ){
					if( k.length > 0 ){
						var c = data[k];
						$.each(c, function(i, x) {
							if (matchSubset(x.value, q)) {
								csub.push(x);
							}
						});
					}
				}				
				return csub;
			} else 
			if (data[q]){
				return data[q];
			} else
			if (options.matchSubset) {
				for (var i = q.length - 1; i >= options.minChars; i--) {
					var c = data[q.substr(0, i)];
					if (c) {
						var csub = [];
						$.each(c, function(i, x) {
							if (matchSubset(x.value, q)) {
								csub[csub.length] = x;
							}
						});
						return csub;
					}
				}
			}
			return null;
		}
	};
};
$.Autocompleter.Select = function (options, input, select, config) {
	var CLASSES = {
		ACTIVE: "ac_over"
	};
	var listItems,
		active = -1,
		data,
		term = "",
		needsInit = true,
		element,
		list;
	function init() {
		if (!needsInit)
			return;
		element = $("<div/>")
		.hide()
		.addClass(options.resultsClass)
		.css("position", "absolute")
		.appendTo(document.body);
		if(options.header != "")
		{
		   $(".ac_results").css({'padding-top':(($(options.header).height() > 0)?($(options.header).height()+10):23)+"px"});
		   if(options.extraParams.headerHeight >0)
		        $(".ac_results").css({'padding-top':((options.extraParams.headerHeight > 0)?(options.extraParams.headerHeight+10):23)+"px"});
	       $("<div style='position:absolute;top:0;left:0;padding:5px 0 5px 0;background-color:#648CCC;text-align:center;border-bottom:1px solid #CCC;border-left:1px solid #cfcfcf;color:white;width:100%;'>"+options.header+"</div>").appendTo(element);
	    }
	    else
	       $(".ac_results").css({'padding-top':'-5px'});

		list = $("<ul/>").appendTo(element).mouseover( function(event) {
			if(target(event).nodeName && target(event).nodeName.toUpperCase() == 'LI') {
	            active = $("li", list).removeClass(CLASSES.ACTIVE).index(target(event));
			    $(target(event)).addClass(CLASSES.ACTIVE);            
	        }
		}).click(function(event) {
			$(target(event)).addClass(CLASSES.ACTIVE);
		     if(list.find("li").text().indexOf("Empty Data") != -1)
		            element.animate({ height: 'hide', left: '-50', opacity: 'hide' }, 'slow');
		        else{
			        select();
			  }
			input.focus();
			return false;
		}).mousedown(function() {
			config.mouseDownOnSelect = true;
		}).mouseup(function() {
			config.mouseDownOnSelect = false;
		});
		
		if( options.width > 0 )
			element.css("width", options.width);
			
		needsInit = false;
	} 
	function target(event) {
		var element = event.target;
		while(element && element.tagName != "LI")
			element = element.parentNode;
		if(!element)
			return [];
		return element;
	}
	function moveSelect(step) {
		listItems.slice(active, active + 1).removeClass(CLASSES.ACTIVE);
		movePosition(step);
        var activeItem = listItems.slice(active, active + 1).addClass(CLASSES.ACTIVE);
        if(options.scroll) {
            var offset = 0;
            listItems.slice(0, active).each(function() {
				offset += this.offsetHeight;
			});
            if((offset + activeItem[0].offsetHeight - list.scrollTop()) > list[0].clientHeight) {
                list.scrollTop(offset + activeItem[0].offsetHeight - list.innerHeight());
            } else if(offset < list.scrollTop()) {
                list.scrollTop(offset);
            }
        }
	};
	function movePosition(step) {
		active += step;
		if (active < 0) {
			active = 0;
		} else if (active >= listItems.size()) {
			active = listItems.size() - 1;
		}
	}
	function limitNumberOfItems(available) {
		return options.max && options.max < available
			? options.max
			: available;
	}
	function fillList() {
		list.empty();
		var max = limitNumberOfItems(data.length);
		for (var i=0; i < max; i++) {
			if (!data[i])
				continue;
			var formatted = options.formatItem(data[i].data, i+1, max, data[i].value, term);
			if ( formatted === false )
				continue;
			var li = $("<li/>").html( options.highlight(formatted, term) ).addClass(i%2 == 0 ? "ac_even" : "ac_odd").appendTo(list)[0];
			$.data(li, "ac_data", data[i]);
		}
		if(max < 1)
		    $.data($("<li/>").css({'color':'gray','font-weight':'bold','text-shadow':'-1px -1px white, 0px 0px #333'}).html("Empty Data").appendTo(list), "","");
		listItems = list.find("li");
		if ( options.selectFirst ) {
			listItems.slice(0, 1).addClass(CLASSES.ACTIVE);
			active = 0;
		}
		if ( $.fn.bgiframe )
			list.bgiframe();
	}
	return {
		display: function(d, q) {
			init();
			data = d;
			term = q;
			fillList();
		},
		next: function() {
			moveSelect(1);
		},
		prev: function() {
			moveSelect(-1);
		},
		pageUp: function() {
			if (active != 0 && active - 8 < 0) {
				moveSelect( -active );
			} else {
				moveSelect(-8);
			}
		},
		pageDown: function() {
			if (active != listItems.size() - 1 && active + 8 > listItems.size()) {
				moveSelect( listItems.size() - 1 - active );
			} else {
				moveSelect(8);
			}
		},
		hide: function() {
			element && element.hide();
			listItems && listItems.removeClass(CLASSES.ACTIVE);
			active = -1;
		},
		visible : function() {
			return element && element.is(":visible");
		},
		current: function() {
			return this.visible() && (listItems.filter("." + CLASSES.ACTIVE)[0] || options.selectFirst && listItems[0]);
		},
		show: function() {
			var offset = $(input).offset();
			element.css({
				width: typeof options.width == "string" || options.width > 0 ? options.width : $(input).width(),
				top: offset.top + input.offsetHeight,
				left: offset.left
			}).show();
            if(options.scroll) {
                list.scrollTop(0);
                list.css({
					maxHeight: options.scrollHeight,
					overflow: 'auto'
				});
				
                if($.browser.msie && typeof document.body.style.maxHeight === "undefined") {
					var listHeight = 0;
					listItems.each(function() {
						listHeight += this.offsetHeight;
					});
					var scrollbarsVisible = listHeight > options.scrollHeight;
                    list.css('height', scrollbarsVisible ? options.scrollHeight : listHeight );
					if (!scrollbarsVisible) {
						listItems.width( list.width() - parseInt(listItems.css("padding-left")) - parseInt(listItems.css("padding-right")) );
					}
                }
                
            }
		},
		selected: function() {
			var selected = listItems && listItems.filter("." + CLASSES.ACTIVE).removeClass(CLASSES.ACTIVE);
			return selected && selected.length && $.data(selected[0], "ac_data");
		},
		emptyList: function (){
			list && list.empty();
		},
		unbind: function() {
			element && element.remove();
		}
	};
};
$.fn.selection = function(start, end) {
	if (start !== undefined) {
		return this.each(function() {
			if( this.createTextRange ){
				var selRange = this.createTextRange();
				if (end === undefined || start == end) {
					selRange.move("character", start);
					selRange.select();
				} else {
					selRange.collapse(true);
					selRange.moveStart("character", start);
					selRange.moveEnd("character", end);
					selRange.select();
				}
			} else if( this.setSelectionRange ){
				this.setSelectionRange(start, end);
			} else if( this.selectionStart ){
				this.selectionStart = start;
				this.selectionEnd = end;
			}
		});
	}
	var field = this[0];
	if ( field.createTextRange ) {
		var range = document.selection.createRange(),
			orig = field.value,
			teststring = "<->",
			textLength = range.text.length;
		range.text = teststring;
		var caretAt = field.value.indexOf(teststring);
		field.value = orig;
		this.selection(caretAt, caretAt + textLength);
		return {
			start: caretAt,
			end: caretAt + textLength
		}
	} else if( field.selectionStart !== undefined ){
		return {
			start: field.selectionStart,
			end: field.selectionEnd
		}
	}
};
})(jQuery);