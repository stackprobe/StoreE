===============================================================================

�@HTTCmd

===============================================================================


���\�t�g�̊T�v

�@�N�����邾���ŊȒP�Ɏg����i�R�}���h���C���ł́j�E�F�u�T�[�o�[�ł��B
�@�h�L�������g���[�g�i���J�t�H���_�j�̔z���ɂ���t�@�C���̉{���E�_�E�����[�h�̂݉\�ł��B


�������

�@Windows 10 Pro �܂��� Windows 10 Home


���C���X�g�[�����@

�@�A�[�J�C�u�̒��g�����[�J���f�B�X�N��̔C�ӂ̏ꏊ�ɃR�s�[���ĉ������B


���A���C���X�g�[�����@

�@���W�X�g���Ȃǂ͈�؎g���Ă��܂���B
�@�t�@�C�����폜���邾���ŃA���C���X�g�[���ł��܂��B


���N�����@

�@�R�}���h���C��

�@�@HTTCmd.exe [DOC-ROOT [PORT-NO [OPTIONS...]]]

�@�@�@DOC-ROOT �� �h�L�������g���[�g�̃t�H���_ (�ȗ����F�J�����g�f�B���N�g��)
�@�@�@PORT-NO  �� �|�[�g�ԍ� (�ȗ����F80)
�@�@�@OPTIONS  �� �g���I�v�V�������Q��


�@���s��

�@�@HTTCmd.exe C:\www\DocRoot

�@�@�@�� "C:\www\DocRoot" ���h�L�������g���[�g�ɂ��āA�|�[�g�ԍ� 80 �ŃT�[�o�[���N������B

�@�@HTTCmd.exe . 8080

�@�@�@�� �J�����g�f�B���N�g�����h�L�������g���[�g�ɂ��āA�|�[�g�ԍ� 8080 �ŃT�[�o�[���N������B

�@�@HTTCmd.exe D:\HP 58946

�@�@�@�� "D:\HP" ���h�L�������g���[�g�ɂ��āA�|�[�g�ԍ� 58946 �ŃT�[�o�[���N������B

�@�@HTTCmd.exe

�@�@�@�� �J�����g�f�B���N�g�����h�L�������g���[�g�ɂ��āA�|�[�g�ԍ� 80 �ŃT�[�o�[���N������B


���I�����@

�@�ȉ��̈����ŋN�����ĉ������B���s���̃T�[�o�[����~���܂��B

�@�@HTTCmd.exe /S


���g���I�v�V����

�@�ȉ��̃I�v�V�����̓��K�v�Ȃ��̂����s���Ɏw�肵�ĉ������B

�@�@/K

�@�@�@�� ��V�t�g�n�L�[���͂ŃT�[�o�[���~�ł���悤�ɂȂ�܂��B

�@�@/T TSV-FILE

�@�@�@�� �t�@�C���g���q�� Content-Type �̑g�ݍ��킹��ǉ�(�f�t�H���g�ݒ���㏑��)���܂��B
�@�@�@�@TSV-FILE �ɂ͈ȉ��̓��e�̃t�@�C�����w�肵�ĉ������B

�@�@�@�@�@�t�@�C���`���FTab-Separated Values (TSV)
�@�@�@�@�@�����R�[�h�FUS-ASCII (UTF-8�ł��ǂ�)
�@�@�@�@�@���s�R�[�h�FCR-LF �܂��� LF

�@�@�@�@�@���s�Q��A�P��ڂɊg���q�A�Q��ڂ� Content-Type ���L�q���܂��B
�@�@�@�@�@�g���q�̓h�b�g����n�܂邱�Ƃɒ��ӂ��ĉ������B

�@�@�@�@�@�L�q��F

�@�@�@�@�@�@.html�y�����^�u�ztext/html�y���s�z
�@�@�@�@�@�@.xlsx�y�����^�u�zapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet�y���s�z
�@�@�@�@�@�@.pdf�y�����^�u�zapplication/pdf�y���s�z

�@�@/H TSV-FILE

�@�@�@�� ���N�G�X�g�w�b�_�� Host �̒l�ɂ���ăh�L�������g���[�g��؂�ւ������ꍇ�Ɏg�p���܂��B
�@�@�@�@TSV-FILE �ɂ͈ȉ��̓��e�̃t�@�C�����w�肵�ĉ������B

�@�@�@�@�@�t�@�C���`���FTab-Separated Values (TSV)
�@�@�@�@�@�����R�[�h�FUTF-8
�@�@�@�@�@���s�R�[�h�FCR-LF �܂��� LF

�@�@�@�@�@���s�Q��A�P��ڂɃz�X�g���A�Q��ڂɃh�L�������g���[�g���L�q���܂��B
�@�@�@�@�@�ǂ̃z�X�g���ɂ���v���Ȃ������ꍇ�́A�R�}���h�����Ɏw�肳�ꂽ�h�L�������g���[�g���g�p���܂��B

�@�@�@�@�@�L�q��F

�@�@�@�@�@�@happy-tea-time.test�y�����^�u�zC:\HTT\DocRoot�y���s�z
�@�@�@�@�@�@darjeeling-tea.test�y�����^�u�zD:\Assam\orange-pekoe�y���s�z
�@�@�@�@�@�@earlgrey.test�y�����^�u�zE:\Earl Grey�y���s�z
�@�@�@�@�@�@localhost�y�����^�u�zC:\HTT\DocRoot�y���s�z
�@�@�@�@�@�@127.0.0.1�y�����^�u�zC:\HTT\DocRoot�y���s�z
�@�@�@�@�@�@127.0.0.2�y�����^�u�zC:\test2�y���s�z
�@�@�@�@�@�@127.0.0.3�y�����^�u�zC:\test3�y���s�z

�@�@/N HTML-FILE

�@�@�@�� ���N�G�X�g���ꂽ�p�X��������Ȃ������ꍇ�ɕ\������鏊���I���W�i���S�O�S�y�[�W��ݒ肵�܂��B
�@�@�@�@�X�e�[�^�X�R�[�h = 404, Content-Type: text/html �Ƌ��� HTML-FILE �̓��e���������܂��B

	/C

�@�@�@�� �傫�ȃt�@�C������������ꍇ Chunked-Encoding ���g�p���܂��B


�@���s��

�@�@HTTCmd.exe C:\www\DocRoot 80 /K

�@�@�@-- /K �̂�

�@�@HTTCmd.exe C:\www\DocRoot 80 /T C:\www\ContentTypes.tsv

�@�@�@-- /T �̂�

�@�@HTTCmd.exe C:\www\DocRoot 80 /H C:\www\DocRoots.tsv

�@�@�@-- /H �̂�

�@�@HTTCmd.exe C:\www\DocRoot 80 /N C:\www\404.html

�@�@�@-- /N �̂�

�@�@HTTCmd.exe C:\www\DocRoot 80 /C

�@�@�@-- /C �̂�

�@�@HTTCmd.exe C:\www\DocRoot 80 /K /T C:\www\ContentTypes.tsv /H C:\www\DocRoots.tsv /N C:\www\404.html /C

�@�@�@-- �S��


���⑫

�@�{�v���O������ HTTCmd.exe �P�̂œ��삵�܂��B


����舵�����

�@�t���[�\�t�g


����҂ւ̘A����

�@stackprobes@gmail.com

�@�s���v�]�ȂǋC�y�ɂ��A���������B

