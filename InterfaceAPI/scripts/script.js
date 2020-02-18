var tbody = document.querySelector('table tbody');
var _aluno = {};

function carregaAlunos(){
	
	document.querySelector('#tbCadastro').style.display = 'none';
	document.querySelector('#dvCarregar').style.display = '';

	tbody.innerHTML = '';

	var xhr = new XMLHttpRequest();
	xhr.open('GET','https://localhost:44341/api/Aluno/Recuperar',true);

	xhr.onreadystatechange = function() {
		var valor = this.responseText

		if(this.readyState == 4) {
			if(this.status == 200) {
				xhr.onload = function() {
					if(valor != undefined && valor != null && valor != ''){
						var alunos = JSON.parse(valor);
						for (var indice in alunos) {
							CarregaLinha(alunos[indice]);
						}
					}
				}

				document.querySelector('#tbCadastro').style.display = '';
				document.querySelector('#dvCarregar').style.display = 'none';
			}
			else if(this.status == 500){
				var erro = JSON.parse(valor);
				console.log(erro.Message);
				console.log(erro.ExceptionMessage);
			}
		}
	}
	
	xhr.setRequestHeader('Authorization', sessionStorage.getItem('token'))
	xhr.send();

}

function SalvarAluno(method, id, corpo){
	if(id === undefined || id === 0)
		id = '';

	var xhr = new XMLHttpRequest();
	xhr.open(method,`https://localhost:44341/api/Aluno/${id}`,false);

	xhr.onreadystatechange = function() {
		if (this.readyState == 4 && this.status == 200) {
			xhr.onload = function() {

				var valor = this.responseText

				if(valor != undefined && valor != null && valor != ''){
					var alunos = JSON.parse(valor);
					for (var indice in alunos) {
						CarregaLinha(alunos[indice]);
					}
				}
			}
		}
	}

	xhr.setRequestHeader('content-type', 'application/json')
	xhr.send(JSON.stringify(corpo));
}

carregaAlunos();

function Cadastrar(){
	var _nome = document.querySelector('#nome').value;
	var _sobrenome = document.querySelector('#sobrenome').value;
	var _telefone = document.querySelector('#telefone').value;
	var _ra = document.querySelector('#ra').value;

	_aluno.Nome = _nome;
	_aluno.Sobrenome = _sobrenome;
	_aluno.Telefone = _telefone;
	_aluno.RA = _ra;

	//console.log(_aluno);

	if(_aluno.Id === undefined || _aluno.Id === 0){
		SalvarAluno('POST',0,_aluno);
		carregaAlunos();
	}else{
		SalvarAluno('PUT',_aluno.Id,_aluno);
		carregaAlunos();
	}

	$('#ModalCadastro').modal('hide')
}

function DeletarAluno(aluno){
	bootbox.confirm({ 
	    message: `<b>Deseja realmente excluir o aluno ${aluno.Nome}</b>`,
	    buttons: {
	        confirm: {
	            label: 'Sim',
	            className: 'btn-success'
	        },
	        cancel: {
	            label: 'Não',
	            className: 'btn-danger'
	        }
	    },
        callback: function(result){
			if(result){
				SalvarAluno('DELETE',aluno.Id);
				carregaAlunos();
			}
        }
	})
}

function CarregaLinha(aluno){

	var trow = `<tr>
					<td>${aluno.Nome}</td>
					<td>${aluno.Sobrenome}</td>
					<td>${aluno.Telefone}</td>
					<td>${aluno.RA}</td>
					<td>
						<button type="button" class="btn btn-sm btn-info" onclick='EditarAluno(${JSON.stringify(aluno)});'>Editar</button>&nbsp;
						<button type="button" class="btn btn-sm btn-danger" onclick='DeletarAluno(${JSON.stringify(aluno)});'>Deletar</button>
					</td>
				</tr
				`
	tbody.innerHTML += trow;
}

function EditarAluno(aluno){
	var tituloModal = document.querySelector('#tituloModal');

	var _nome = document.querySelector('#nome');
	var _sobrenome = document.querySelector('#sobrenome');
	var _telefone = document.querySelector('#telefone');
	var _ra = document.querySelector('#ra');

	var btnSalvar = document.querySelector('#btnSalvar');

	tituloModal.textContent = `Editar Aluno ${aluno.Nome}`

	_nome.value = aluno.Nome;
	_sobrenome.value = aluno.Sobrenome;
	_telefone.value = aluno.Telefone;
	_ra.value = aluno.RA;

	btnSalvar.textContent = 'Salvar';

	_aluno = aluno;

	//console.log(_aluno);
	$('#ModalCadastro').modal('show')
}

function abrirModalCadastro(){

	var tituloModal = document.querySelector('#tituloModal');

	var _nome = document.querySelector('#nome');
	var _sobrenome = document.querySelector('#sobrenome');
	var _telefone = document.querySelector('#telefone');
	var _ra = document.querySelector('#ra');

	var btnSalvar = document.querySelector('#btnSalvar');

	tituloModal.textContent = 'Cadastrar Aluno'

	_aluno = {};

	_nome.value = '';
	_sobrenome.value = '';
	_telefone.value = '';
	_ra.value = '';

	btnSalvar.textContent = 'Cadastrar';

	$('#ModalCadastro').modal('show')
}