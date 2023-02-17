function plus() {
	let rel = document.getElementById("amount");
	if (rel.value < 999)
		rel.value = Number(rel.value) + 1;
	else
		alert("Максимальне число одиниць 999");
}

function minus() {
	let rel = document.getElementById("amount");
	if (rel.value > 0)
		if (rel.value > 1)
			rel.value = Number(rel.value) - 1;
		else
			deleteItem();
}

function deleteItem() {

}