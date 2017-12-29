$(function () {

  //form ajax function
  var ajaxFormSubmit = function () {
    var $form = $(this);
    var options = {
      url: $form.attr('action'),
      type: $form.attr('method'),
      data: $form.serialize()
    }

    $.ajax(options).done(function (data) {
      var $target = $($form.attr("iajax-target"));
      //$target.replaceWith(data);
      var $newHtml = $(data);
      $target.replaceWith($newHtml);
      $newHtml.effect("highlight");
    });
    return false;
  };
  $("form[iajax='true']").submit(ajaxFormSubmit);
  //form ajax function//


  //Autocomplete function
  var submitAutocompleteForm = function (event, ui) {
    var $input = $(this);
    $input.val(ui.item.label);

    var $form = $input.parents("form:first");
    $form.submit();
  };

  var createAutocomplete = function() {
    var $input = $(this);
    
    var options = {
      source: $input.attr("autocomplete-action"),
      select: submitAutocompleteForm
    };
    $input.autocomplete(options);
  }
  $("input[autocomplete-action]").each(createAutocomplete);

  
})