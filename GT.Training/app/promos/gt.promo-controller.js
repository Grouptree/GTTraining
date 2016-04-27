(function initialisePromoController() {

    angular.module('gt.app').controller('PromosController', ['promosFactory', controller]);

    function controller(promosFactory) {

        var self = this;
        
        promosFactory.getPromosForCurrentAsset().then(function (results) {                        

            if (results.data) {
                self.promo = results.data;
            }
            
        });

        self.getTags = function (promo) {
            if (!promo || !promo.Tags) return '';
            return promo.Tags.join(',');
        };

    };

})();