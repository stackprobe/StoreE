===============
RemoteCmdServer
===============

----
�R�}���h

	RemoteCmdServer.exe [/P] �|�[�g�ԍ� �o�b�`�t�@�C��-DIR �t�@�C������M-DIR

		/P ... POST-���N�G�X�g�̂ݎ󂯕t����B


----
�I�����@

	RemoteCmdServer.exe /S

	�܂��́A�L�[����


----
�A�N�Z�X���@

	http://localhost/B/aaa/bbb/ccc.xxx

		(�o�b�`�t�@�C��-DIR)\aaa\bbb\ccc.xxx ���o�b�`�t�@�C���Ƃ��Ď��s����B


	http://localhost/D/aaa/bbb/ccc.xxx

		(�t�@�C������M-DIR)\aaa\bbb\ccc.xxx ���_�E�����[�h����B


	http://localhost/U/aaa/bbb/ccc.xxx

		POST-���N�G�X�g

			���N�G�X�g-BODY�̓��e�� (�t�@�C������M-DIR)\aaa\bbb\ccc.xxx �ɏo�͂���B

		GET-���N�G�X�g

			��̃t�@�C�� (�t�@�C������M-DIR)\aaa\bbb\ccc.xxx ���쐬����B

		���t�H���_��������΍쐬����B


	http://localhost/A/aaa/bbb/ccc.xxx

		POST-���N�G�X�g

			���N�G�X�g-BODY�̓��e�� (�t�@�C������M-DIR)\aaa\bbb\ccc.xxx �ɒǋL����B

		GET-���N�G�X�g

			��̃o�C�g��� (�t�@�C������M-DIR)\aaa\bbb\ccc.xxx �ɒǋL����B

		���t�H���_��������΍쐬����B


	http://localhost/K/aaa/bbb/ccc.xxx

		(�t�@�C������M-DIR)\aaa\bbb\ccc.xxx ���폜����B


----
�⑫

���M�t�@�C���ő�T�C�Y = 100 TB

