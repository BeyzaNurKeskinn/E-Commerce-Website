
var slider = new Vue({
	el: "#slider",
	data: {
		sliderVerisi: []
	},
	mounted: function () {
		this.getirSlider();
	},
	methods: {
		getirSlider: function () {
			var vm = this;
			$.ajax({ url: "/Slider/GetirSlider", method: "POST" })
				.done(function(data) {
					vm.sliderVerisi = data.gelendata;
				});
		}
	}

})
