(function initialiseRegistrationController() {

	angular.module('gt.app').controller('RegistrationController', ['registrationFactory', controller]);

	function controller(registrationFactory) {

		var self = this;

		self.userDetails = {
			firstName: '',
			lastName: '',
			email: '',
			password: ''
		};		

		self.currentMessage;

		function setMessage(messageText, messageType) {
			self.currentMessage = {};
			self.currentMessage.message = messageText;
			self.currentMessage[messageType] = true;
		};

		function clearMessage() {
			self.currentMessage = undefined;
		};

		self.register = function () {

			if (!self.registrationForm.$valid) {
				setMessage('Please make sure all details are inputted correctly.', 'error');
				return;
			} else if (self.userDetails.password !== self.userDetails.confirmPassword) {
				setMessage('Please make sure the passwords match.', 'error');
				return;
			}

			registrationFactory.register(self.userDetails).then(function (result) {
				
				if (result.data.successful === true) {
					setMessage('Successfully registered.', 'success');
					window.location.href = result.data.redirectURL;
				} else {
					setMessage('Registration failed.', 'error');
				}

			}, function () {
			    setMessage('Registration failed.', 'error');
			});
		
		};

	};

})();