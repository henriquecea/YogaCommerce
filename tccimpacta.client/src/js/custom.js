// jQuery( function($){
$(document).ready(function () {

  $('.owl-carousel').owlCarousel();

  let titulos = $('h4') // tag

  console.log('teste')

  let itens = $('.featured-item') // class

  let destaques = $('#featured') // id

  // let comprar = $('.single-product.html')


  // console.log(titulos.first());

  // Configuração de produtos

  $('.featured-item a').addClass('btn btn-dark stretch-link');

  // $('.featured-item:first h4').append('<span class="badge bg-secondary">Novo</span>')



  // $('.featured-item:first h4').start('<span class="badge bg-secondary">Novo</span>')
  // $('.featured-item:first h4').html('<span class="badge bg-secondary">Novo</span>')
  // $('.featured-item:first h4').addClass('active')
  // $('.featured-item:first h4').removeClass('active')
  // $('.featured-item:first h4').toggleClass('active')
  // $('.featured-item:first h4').hide()
  // $('.featured-item:first h4').show()
  // $('.featured-item:first h4').fadeIn(2000)
  // $('.featured-item:first h4').fadeOut()
  //  $('.featured-item:first h4').css('color', '#f00')


  $('.featured-item h4').dblclick(function () {

    $(this).css({
      'color': '#f00',
      'background': '#ff0',
      'font-weight': '100',
    });

  });

  /*
   * Manipulação de eventos
   */
  $('.featured-item a').on('blur', function (event) {

    event.preventDefault();

    alert('Produto esgotado');

  })

  $('h4, h6').css({ "display": "flex", "justify-content": "center", "align-items": "center", "padding": "1vh" })

  $('.container-a').css({ "display": "flex", "justify-content": "center", "align-items": "center", "height:": "100vh", "padding-top": "2vh" })

  $('.btn-dark').css({ "color": "rgb(2, 97, 198)", "background-color": "whitesmoke" })

  $('.btn-dark').on({
    mouseenter: function (event) {
      $(this).css({ "background-color": "#ffd779", "color": "black" });

    },

    mouseleave: function (event) {
      $(this).css({ "color": "rgb(2, 97, 198)", "background-color": "whitesmoke" })
    }
  })


  const duracao = 0 // equivale a 1 segundo 
  $('.featured-item:nth(0)')
    .hide(duracao)
    .show()
    .fadeIn(duracao)
    .fadeOut(duracao)
    .toggle(duracao)

  $('#form-submit').on('click', function (event) {
    event.preventDefault()

    if ($('email').val().length < 1) {
      $('#email').animate({
        'border': '2px solid #f00'
      })
    }
  })

  $('.nav-modal-open').on('click', function (e) {
    e.preventDefault();

    let elem = $(this).attr('rel')

    $('.modal-body').html($('#' + elem).html())
    $('.modal-header h5.modal-title').html($(this).text())

    let myModal = new bootstrap.Modal($('#modalId'))

    myModal.show()

  })

  function validate(elem) {
    var value = $(elem).val();
    var fieldName = $(elem).attr('name');

    if (value == '') {
      elem.parent().find('.text-muted').show();
      $(elem).addClass('invalid');
      return false;
    } else {
      elem.parent().find('.text-muted').hide();
      $(elem).removeClass('invalid');
    }

    switch (fieldName) {
      case 'nome':
        if (value.length <= 2) {
          elem.parent().find('.text-muted').text('O nome deve conter mais que dois caracteres').show()
          $(elem).addClass('invalid');
          return false
        }
        break;

      case 'email':
        var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]{2,3}$/
        if (!emailRegex.test(value)) {
          elem.parent().find('.text-muted').text('Por favor insira um e-mail válido').show()
          $(elem).addClass('invalid');
          return false
        }
        break;

      case 'cpf':
        var cpfRegex = /^\d{3}\.\d{3}\.\d{3}\-\d{2}$/;
        if (!cpfRegex.test(value)) {
          elem.parent().find('.text-muted').text('Por favor, insira um CPF válido').show();
          $(elem).addClass('invalid');
          return false;
        }
        break;
    }

    return true;

  }


  $('body').on('submit', '.modal-body .form', function (e) {

    e.preventDefault()

    const inputName = $('#nome')
    const inputEmail = $('#email')

    validate(inputName)
    validate(inputEmail)

    if (inputEmail.hasClass('invalid') || inputName.hasClass('invalid')) {
      return false
      console.log('Verificar campos obrigatórios')
    } else {
      $(this).submit()
    }

  })


  $('body').on('blur', '#nome', function () {
    validate($(this))
  })


  $('body').on('blur', '#email', function () {
    validate($(this))
  })


  $('body').on('blur', '#date', function () {
    validate($(this))
    $(this).mask('00/00/0000');
  })


  $('body').on('focus', '#date', function () {
    $(this).datepicker()
  })

  $('body').on('blur', '#time', function () {
    validate($(this))
    $(this).mask('00:00');
  })


  $('body').on('blur', '#cep', function () {
    validate($(this))
    $(this).mask('00000-000');

  })


  $('body').on('blur', '#phone', function () {
    validate($(this))
    $(this).mask('0000-0000');
  })


  $('body').on('blur', '#cpf', function () {
    validate($(this))
    $(this).mask('000.000.000-00')

  })

})
